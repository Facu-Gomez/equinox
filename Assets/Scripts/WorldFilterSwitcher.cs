using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using System.Collections;

public class WorldFilterSwitcher : MonoBehaviour
{
    [Header("Filtros")]
    [Tooltip("Primer perfil: Frío (Alba) | Segundo perfil: Calor (Ocaso)")]
    public VolumeProfile[] filterProfiles;
    public float switchInterval = 10f;
    public float fadeDuration = 1.5f;

    [Header("Personajes")]
    public GameObject alba;
    public GameObject ocaso;

    private Volume postProcessVolume;
    private int currentFilterIndex = 0;
    private float timer = 0f;

    private SpriteRenderer albaRenderer;
    private SpriteRenderer ocasoRenderer;
    private bool isSwitching = false;

    void Awake()
    {
        // Si no estamos en el menú, no aplicar este filtro
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (filterProfiles == null || filterProfiles.Length < 2)
        {
            Debug.LogWarning("Asigna al menos 2 perfiles en filterProfiles (frío y calor).");
            enabled = false;
            return;
        }

        // Buscar o crear el Volume global
        postProcessVolume = FindFirstObjectByType<Volume>();
        if (postProcessVolume == null)
        {
            GameObject volumeObj = new GameObject("GlobalPostProcessVolume");
            postProcessVolume = volumeObj.AddComponent<Volume>();
            postProcessVolume.isGlobal = true;
        }

        // Aplicar primer filtro (frío por defecto)
        postProcessVolume.profile = ScriptableObject.Instantiate(filterProfiles[0]);
        postProcessVolume.weight = 1f;

        // Obtener renderers de los personajes
        if (alba != null) albaRenderer = alba.GetComponent<SpriteRenderer>();
        if (ocaso != null) ocasoRenderer = ocaso.GetComponent<SpriteRenderer>();

        // Configurar visibilidad inicial
        SetInitialCharacters();
    }

    void Update()
    {
        if (isSwitching) return; // prevenir superposición de fades

        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            timer = 0f;
            int nextIndex = (currentFilterIndex + 1) % filterProfiles.Length;
            StartCoroutine(SwitchWorld(nextIndex));
        }
    }

    IEnumerator SwitchWorld(int nextIndex)
    {
        isSwitching = true;

        VolumeProfile nextProfile = ScriptableObject.Instantiate(filterProfiles[nextIndex]);
        VolumeProfile oldProfile = postProcessVolume.profile;

        float elapsed = 0f;

        // Filtros
        Volume blendVolume = new GameObject("BlendVolume").AddComponent<Volume>();
        blendVolume.isGlobal = true;
        blendVolume.profile = nextProfile;
        blendVolume.weight = 0f;

        // Personajes
        SpriteRenderer fadeIn = (nextIndex == 0) ? albaRenderer : ocasoRenderer;
        SpriteRenderer fadeOut = (nextIndex == 0) ? ocasoRenderer : albaRenderer;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            // Transición de filtros
            blendVolume.weight = Mathf.Lerp(0f, 1f, t);
            postProcessVolume.weight = Mathf.Lerp(1f, 0f, t);

            // Fade de personajes
            if (fadeIn != null)
                fadeIn.color = new Color(1, 1, 1, Mathf.Lerp(0f, 1f, t));
            if (fadeOut != null)
                fadeOut.color = new Color(1, 1, 1, Mathf.Lerp(1f, 0f, t));

            yield return null;
        }

        // Finalizar transición
        postProcessVolume.profile = nextProfile;
        postProcessVolume.weight = 1f;
        Destroy(blendVolume.gameObject);

        if (fadeIn != null) fadeIn.color = new Color(1, 1, 1, 1f);
        if (fadeOut != null) fadeOut.color = new Color(1, 1, 1, 0f);

        currentFilterIndex = nextIndex;
        isSwitching = false;
    }

    void SetInitialCharacters()
    {
        if (albaRenderer != null)
            albaRenderer.color = new Color(1, 1, 1, currentFilterIndex == 0 ? 1f : 0f);

        if (ocasoRenderer != null)
            ocasoRenderer.color = new Color(1, 1, 1, currentFilterIndex == 1 ? 1f : 0f);
    }
}
