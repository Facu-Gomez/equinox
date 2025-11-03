using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassFragment : MonoBehaviour
{
    [Header("ID fragmento")]
    public string fragmentID;

    [Header("Nombre de la escena del Hub")]
    public string hubSceneName = "WorldHub";

    [Header("Posición de spawn en el Hub")]
    public string spawnPointName = "FragmentSpawnPoint";

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;
            CollectFragment();
        }
    }

    private void CollectFragment()
    {
        FragmentManager.MarkFragmentCollected(fragmentID);

        PlayerPrefs.SetString("SpawnPoint", spawnPointName);

        SceneManager.LoadScene(hubSceneName);
    }
}
