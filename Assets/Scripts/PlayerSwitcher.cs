using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject mundoOcaso;
    public GameObject mundoAlba;
    private GameObject mundoActivo;

    private CameraFollow cameraFollow;

    public static PlatformController.Mundo MundoActual { get; private set; }

    void Start()
    {
        mundoActivo = mundoAlba;
        mundoOcaso.SetActive(false);
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        MundoActual = PlatformController.Mundo.Alba;
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
            CambiarMundo(PlatformController.Mundo.Ocaso);
        }
        else
        {
            CambiarMundo(PlatformController.Mundo.Alba);
        }
    }

    public void CambiarMundo(PlatformController.Mundo nuevoMundo)
    {
        MundoActual = nuevoMundo;

        bool esAlba = (nuevoMundo == PlatformController.Mundo.Alba);

        mundoAlba.SetActive(esAlba);
        mundoOcaso.SetActive(!esAlba);
        mundoActivo = esAlba ? mundoAlba : mundoOcaso;

        cameraFollow.target = BuscarHijoPorTag(mundoActivo, "Player").transform;

        WorldEventManager.Instance?.MundoCambiado(nuevoMundo);
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
        return null;
    }
}
