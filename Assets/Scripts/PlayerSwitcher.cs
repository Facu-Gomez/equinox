using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject playerBlanco;
    public GameObject playerRojo;

    private GameObject jugadorActivo;

    void Start()
    {

        jugadorActivo = playerBlanco;
        playerBlanco.SetActive(true);
        playerRojo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarJugador();
        }
    }

    void CambiarJugador()
    {
        if (jugadorActivo == playerBlanco)
        {
            playerBlanco.SetActive(false);
            playerRojo.SetActive(true);
            jugadorActivo = playerRojo;
        }
        else
        {
            playerRojo.SetActive(false);
            playerBlanco.SetActive(true);
            jugadorActivo = playerBlanco;
        }
    }
}
