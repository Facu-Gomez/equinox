using UnityEngine;
using TMPro;

public class ChargeSource : MonoBehaviour
{
    public GameObject player;
    public TMP_Text promptText;
    public float detectionRange = 3f;
    public float chargeTime = 3f;

    public PlatformController[] plataformas; 

    private float currentCharge = 0f;
    private bool isFullyCharged = false;

    void Start()
    {
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
                    promptText.text = "Fuente cargada";

                    foreach (PlatformController plataforma in plataformas)
                    {
                        plataforma.BajarPlataforma();
                    }
                }
                else
                {
                    promptText.text = "Cargando fuente: " + Mathf.RoundToInt(currentCharge) + "%";
                }
            }
            else if (!isFullyCharged)
            {
                promptText.text = currentCharge > 0 ? 
                    "Cargando fuente: " + Mathf.RoundToInt(currentCharge) + "%" 
                    : "Mantener apretado Q para cargar la fuente";
            }
            else
            {
                promptText.text = "Fuente cargada";
            }
        }
        else
        {
            if (!isFullyCharged)
                currentCharge = 0f;

            promptText.text = "";
        }
    }
}