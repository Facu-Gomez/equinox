using UnityEngine;
using System.Collections.Generic;

public class FragmentManager : MonoBehaviour
{
    public static FragmentManager Instance;

    private static HashSet<string> collectedFragments = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void MarkFragmentCollected(string id)
    {
        collectedFragments.Add(id);
        PlayerPrefs.SetInt(id, 1);
        PlayerPrefs.Save();
    }

    public static bool IsFragmentCollected(string id)
    {
        if (collectedFragments.Contains(id))
            return true;

        return PlayerPrefs.GetInt(id, 0) == 1;
    }
}
