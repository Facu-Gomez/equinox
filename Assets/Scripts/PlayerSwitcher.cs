using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject mundoOcaso;
    public GameObject mundoAlba;
    private GameObject mundoActivo;

    void Start()
    {
        mundoActivo = mundoAlba;
        mundoOcaso.SetActive(false);
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
    }
}
