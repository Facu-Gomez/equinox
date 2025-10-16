using UnityEngine;
using TMPro;

public class ChargeSource : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject player;
    public TMP_Text promptText;
    public float detectionRange = 3f;
    public float chargeTime = 3f;

    [Header("Plataformas conectadas")]
    public PlatformController[] plataformas;

    private float currentCharge = 0f;
    private bool isFullyCharged = false;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (promptText != null)
            promptText.text = "";
    }

    void Update()
    {
        if (player == null || promptText == null) return;

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance <= detectionRange)
        {
            if (!isFullyCharged)
            {
                promptText.text = Input.GetKey(KeyCode.Q)
                    ? "Cargando fuente: " + Mathf.RoundToInt(currentCharge) + "%"
                    : "Mantener Q para cargar";
            }
            else
            {
                promptText.text = "Fuente cargada";
            }

            if (!isFullyCharged && Input.GetKey(KeyCode.Q))
            {
                currentCharge += Time.deltaTime / chargeTime * 100f;

                if (currentCharge >= 100f)
                {
                    currentCharge = 100f;
                    isFullyCharged = true;
                    promptText.text = "Fuente cargada";
                    ActivarPlataformas();
                }
            }
        }
        else
        {
            if (!isFullyCharged)
                currentCharge = 0f;

            promptText.text = "";
        }
    }

    void ActivarPlataformas()
    {
        foreach (PlatformController plataforma in plataformas)
        {
            if (plataforma == null) continue;

            var mundoPlataforma = plataforma.mundoDeEsta;

            WorldEventManager.Instance.AgregarEvento(mundoPlataforma, () =>
            {
                plataforma.Activar();
            });
        }
    }
}
