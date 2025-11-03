using UnityEngine;

public class MirrorFragmentDisplay : MonoBehaviour
{
    [System.Serializable]
    public class MirrorPiece
    {
        public string fragmentID;
        public GameObject fragmentObject;
    }

    [Header("Fragmentos en el espejo")]
    public MirrorPiece[] mirrorPieces;

    private void Start()
    {
        UpdateMirror();
    }

    public void UpdateMirror()
    {
        foreach (var piece in mirrorPieces)
        {
            bool collected = FragmentManager.IsFragmentCollected(piece.fragmentID);
            piece.fragmentObject.SetActive(collected);
        }
    }
}
