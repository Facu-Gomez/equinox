using UnityEngine;
using TMPro;

public class ChargeSource : MonoBehaviour
{
    public GameObject player;
    public TMP_Text promptText;
    public float detectionRange = 3f;
    public float chargeTime = 3f;

    [Header("Plataformas conectadas")]
    public PlatformController[] plataformas;

    private float currentCharge = 0f;
    private bool isFullyCharged = false;
    public bool IsFullyCharged => isFullyCharged;

    void Start()
    {
        if (promptText != null)
            promptText.text = "Press Q";
    }

    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance <= detectionRange)
        {
            if (!isFullyCharged && Input.GetKey(KeyCode.Q))
            {
                currentCharge += Time.deltaTime / chargeTime * 100f;

                if (currentCharge >= 100f)
                {
                    currentCharge = 100f;
                    isFullyCharged = true;
  foreach (var plataforma in plataformas)


                    {


                        if (plataforma != null)


                            plataforma.Activar();


                    }
                    if (promptText != null)
                        promptText.text = "Fuente cargada";
                }
                else if (promptText != null)
                {
                    promptText.text = "Cargando fuente: " + Mathf.RoundToInt(currentCharge) + "%";
                }
            }
            else if (!isFullyCharged && promptText != null)
            {
                promptText.text = currentCharge > 0 ?
                    "Cargando fuente: " + Mathf.RoundToInt(currentCharge) + "%"
                    : "Mantener apretado Q para cargar la fuente";
            }
            else if (promptText != null)
            {
                promptText.text = "Fuente cargada";
            }
        }
        else
        {
            if (!isFullyCharged)
                currentCharge = 0f;

            if (promptText != null)
                promptText.text = "";
        }
    }
}
