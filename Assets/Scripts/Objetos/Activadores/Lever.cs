using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [Header("Configuración")]
    public float interactionRange = 3f;
    public KeyCode interactKey = KeyCode.F;
    public GameObject uiIndicator;
    public PlatformController[] plataformasConectadas;
    public UnityEvent onLeverActivated;

    private GameObject player;
    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (uiIndicator != null) uiIndicator.SetActive(false);
    }

    void Update()
    {
        if (player == null || !player.activeInHierarchy)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("⚠️ No se encontró ningún jugador con tag 'Player'");
            return;
        }

        float distance = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log("Distancia al jugador: " + distance);

        if (distance <= interactionRange && !isActivated)
        {
            if (uiIndicator != null) uiIndicator.SetActive(true);

            if (Input.GetKeyDown(interactKey))
            {
                ActivarPalanca();
            }
        }
        else
        {
            if (uiIndicator != null) uiIndicator.SetActive(false);
        }
    }

    void ActivarPalanca()
    {
        if (isActivated) return;

        isActivated = true;
        Debug.Log("Palanca activada!");
        foreach (var plataforma in plataformasConectadas)
        {
            if (plataforma != null)
                plataforma.Activar();

        }

        onLeverActivated?.Invoke();

        if (uiIndicator != null) uiIndicator.SetActive(false);
    }
}
