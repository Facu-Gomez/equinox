using UnityEngine;

public class Bridge : MonoBehaviour
{
    public void ActivateBridge()
    {
        gameObject.SetActive(true);
        Debug.Log("¡Puente activado!");
    }
}
