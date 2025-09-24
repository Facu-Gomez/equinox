using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WorldFilterSwitcher : MonoBehaviour
{
    public VolumeProfile[] filterProfiles;
    public float switchInterval = 10f;

    private Volume postProcessVolume;
    private int currentFilterIndex = 0;
    private float timer = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            enabled = false;
            return;
        }

        postProcessVolume = FindFirstObjectByType<Volume>();
        if (postProcessVolume == null)
        {
            GameObject volumeObj = new GameObject("GlobalPostProcessVolume");
            postProcessVolume = volumeObj.AddComponent<Volume>();
            postProcessVolume.isGlobal = true;
        }
        else
        {
            postProcessVolume.isGlobal = true;
        }

        if (filterProfiles == null || filterProfiles.Length == 0)
        {
            filterProfiles = new VolumeProfile[1];
            filterProfiles[0] = ScriptableObject.CreateInstance<VolumeProfile>();
        }

        // aplicar el primer filtro
        postProcessVolume.profile = ScriptableObject.Instantiate(filterProfiles[currentFilterIndex]);
        postProcessVolume.weight = 1f;
    }

    void Update()
    {
        if (postProcessVolume == null || filterProfiles.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            timer = 0f;
            currentFilterIndex = (currentFilterIndex + 1) % filterProfiles.Length;
            postProcessVolume.profile = ScriptableObject.Instantiate(filterProfiles[currentFilterIndex]);
        }
    }
}
