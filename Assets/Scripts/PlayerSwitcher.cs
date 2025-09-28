using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject mundoOcaso;
    public GameObject mundoAlba;
    private GameObject mundoActivo;

    private CameraFollow cameraFollow;
    void Start()
    {
        mundoActivo = mundoAlba;
        mundoOcaso.SetActive(false);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cambiar();
        }
    }

    void Cambiar()
    {
        if (mundoActivo == mundoAlba)
        {
            mundoAlba.SetActive(false);
            mundoOcaso.SetActive(true);
            mundoActivo = mundoOcaso;

        }
        else
        {
            mundoAlba.SetActive(true);
            mundoOcaso.SetActive(false);
            mundoActivo = mundoAlba;
        }
         cameraFollow.target = BuscarHijoPorTag(mundoActivo, "Player").transform;
    }
    public GameObject BuscarHijoPorTag(GameObject padre, string tag)
{
    foreach (Transform hijo in padre.GetComponentsInChildren<Transform>(true))
    {
        if (hijo.CompareTag(tag))
        {
            return hijo.gameObject;
        }
    }
    return null; // No encontrado
}
}
