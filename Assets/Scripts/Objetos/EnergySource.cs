using UnityEngine;
using TMPro;
using System.Collections;

public class ChargeSource : MonoBehaviour
{
    public GameObject player;
    public TMP_Text promptText;
    public float detectionRange = 3f;
    public float chargeTime = 3f;

    [Header("Plataformas conectadas")]
    public PlatformController[] plataformas;

    [SerializeField]private float currentCharge = 0f;
    [SerializeField]private bool isFullyCharged = false;
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
             switch (player.gameObject.name)
        {
            case "Alba":
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
            break;
                case "Ocaso":
                    {
                                   if ( Input.GetKey(KeyCode.Q)&&isFullyCharged )
            {
                currentCharge += (Time.deltaTime / chargeTime * 100f)*-1;

                if (currentCharge <= 0f)
                {
                    currentCharge = 0f;
                    isFullyCharged = false;
  foreach (var plataforma in plataformas)


                    {


                        if (plataforma != null)


                            plataforma.Activar();


                    }
                    if (promptText != null)
                        promptText.text = "Fuente drenada";
                }
                else if (promptText != null)
                {
                    promptText.text = "Drenando fuente: " + Mathf.RoundToInt(currentCharge) + "%";
                }
            }
            else if (isFullyCharged && promptText != null)
            {
                promptText.text = currentCharge < 100 ?
                    "Drenando fuente: " + Mathf.RoundToInt(currentCharge) + "%"
                    : "Mantener apretado Q para drenar la fuente";
            }
            else if (promptText != null)
            {
                promptText.text = "Fuente drenada";
            } 

                        
                    }
                    break;
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
