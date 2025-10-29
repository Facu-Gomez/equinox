using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class WorldFilter : MonoBehaviour
{
    [Header("Filtros visuales")]
    public VolumeProfile filtroAlba;
    public VolumeProfile filtroOcaso;
    public float fadeDuration = 1f;

    [Header("Referencias de cámara")]
    public Camera camaraMundo;
    public Camera camaraPersonajes;

    private Volume postProcessVolume;
    private bool isTransitioning = false;

    void Start()
    {
        postProcessVolume = FindFirstObjectByType<Volume>();
        if (postProcessVolume == null)
        {
            Debug.LogError("No se encontró un Volume global en la escena.");
            return;
        }

        postProcessVolume.profile = filtroAlba;
        postProcessVolume.weight = 1f;

        if (WorldEventManager.Instance != null)
            WorldEventManager.Instance.OnMundoCambiado += OnMundoCambiado;
    }

    private void OnDestroy()
    {
        if (WorldEventManager.Instance != null)
            WorldEventManager.Instance.OnMundoCambiado -= OnMundoCambiado;
    }

    private void OnMundoCambiado(PlatformController.Mundo nuevoMundo)
    {
        if (!isTransitioning)
            StartCoroutine(TransicionFiltro(nuevoMundo));
    }

    private IEnumerator TransicionFiltro(PlatformController.Mundo nuevoMundo)
    {
        isTransitioning = true;
        float t = 0f;

        while (t < fadeDuration)
        {
            postProcessVolume.weight = Mathf.Lerp(1f, 0f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        postProcessVolume.weight = 0f;

        if (nuevoMundo == PlatformController.Mundo.Ocaso)
            postProcessVolume.profile = filtroOcaso;
        else
            postProcessVolume.profile = filtroAlba;

        t = 0f;
        while (t < fadeDuration)
        {
            postProcessVolume.weight = Mathf.Lerp(0f, 1f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        postProcessVolume.weight = 1f;

        isTransitioning = false;
    }
}
