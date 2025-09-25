using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject mundoOcaso;
    public GameObject mundoLuz;
    private GameObject mundoActivo;

    void Start()
    {
        mundoActivo = mundoLuz;
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
        if (mundoActivo == mundoLuz)
        {
            mundoLuz.SetActive(false);
            mundoOcaso.SetActive(true);
            mundoActivo = mundoOcaso;
        }
        else
        {
            mundoLuz.SetActive(true);
            mundoOcaso.SetActive(false);
            mundoActivo = mundoLuz;
        }
    }
}
