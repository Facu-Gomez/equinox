using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class WorldFilterSwitcher : MonoBehaviour
{
    [Header("Filtros")]
    public VolumeProfile[] filterProfiles; // [0] frío, [1] calor
    public float switchInterval = 10f;
    public float fadeDuration = 1f; // segundos del fade

    [Header("Personajes")]
    public GameObject alba;   // personaje frío
    public GameObject ocaso;  // personaje calor

    private Volume postProcessVolume;
    private int currentFilterIndex = 0;
    private float timer = 0f;

    private SpriteRenderer albaRenderer;
    private SpriteRenderer ocasoRenderer;

    void Start()
    {
        // Buscar o crear un Volume
        postProcessVolume = FindFirstObjectByType<Volume>();
        if (postProcessVolume == null)
        {
            GameObject volumeObj = new GameObject("GlobalPostProcessVolume");
            postProcessVolume = volumeObj.AddComponent<Volume>();
            postProcessVolume.isGlobal = true;
        }

        if (filterProfiles == null || filterProfiles.Length < 2)
        {
            Debug.LogWarning("Asigna al menos 2 perfiles en filterProfiles (frío y calor).");
            enabled = false;
            return;
        }

        // Aplicar filtro inicial
        postProcessVolume.profile = ScriptableObject.Instantiate(filterProfiles[currentFilterIndex]);
        postProcessVolume.weight = 1f;

        // Cachear SpriteRenderers
        if (alba != null) albaRenderer = alba.GetComponent<SpriteRenderer>();
        if (ocaso != null) ocasoRenderer = ocaso.GetComponent<SpriteRenderer>();

        // Estado inicial
        SetInitialCharacters();
    }

    void Update()
    {
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
        VolumeProfile nextProfile = ScriptableObject.Instantiate(filterProfiles[nextIndex]);

        // Filtro inicial para transición
        Volume tempVolume = postProcessVolume;
        VolumeProfile oldProfile = tempVolume.profile;
        tempVolume.profile = nextProfile;
        tempVolume.weight = 0f; // empezar "apagado"

        // Fade de personajes + filtro al mismo tiempo
        SpriteRenderer fadeIn = (nextIndex == 0) ? albaRenderer : ocasoRenderer;
        SpriteRenderer fadeOut = (nextIndex == 0) ? ocasoRenderer : albaRenderer;

        float elapsed = 0f;
        float startAlphaIn = fadeIn != null ? fadeIn.color.a : 0f;
        float startAlphaOut = fadeOut != null ? fadeOut.color.a : 1f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            // Filtro
            tempVolume.weight = Mathf.Lerp(0f, 1f, t);

            // Personajes
            if (fadeIn != null)
                fadeIn.color = new Color(1, 1, 1, Mathf.Lerp(startAlphaIn, 1f, t));
            if (fadeOut != null)
                fadeOut.color = new Color(1, 1, 1, Mathf.Lerp(startAlphaOut, 0f, t));

            yield return null;
        }

        // Finalizar estados
        tempVolume.weight = 1f;
        if (fadeIn != null) fadeIn.color = new Color(1, 1, 1, 1f);
        if (fadeOut != null) fadeOut.color = new Color(1, 1, 1, 0f);

        currentFilterIndex = nextIndex;
    }

    void SetInitialCharacters()
    {
        if (albaRenderer != null)
            albaRenderer.color = new Color(1, 1, 1, currentFilterIndex == 0 ? 1f : 0f);

        if (ocasoRenderer != null)
            ocasoRenderer.color = new Color(1, 1, 1, currentFilterIndex == 1 ? 1f : 0f);
    }
}