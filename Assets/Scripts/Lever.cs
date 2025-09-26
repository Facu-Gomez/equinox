using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [Header("Configuración")]
    public float interactionRange = 3f;
    public KeyCode interactKey = KeyCode.F;
    public GameObject uiIndicator; 
    public UnityEvent onLeverActivated;

    private GameObject player;
    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (uiIndicator != null)
            uiIndicator.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(player.transform.position, transform.position);


        if (distance <= interactionRange && !isActivated)
        {
            if (uiIndicator != null)
                uiIndicator.SetActive(true);

            if (Input.GetKeyDown(interactKey))
            {
                ToggleLever();
            }
        }
        else
        {
            if (uiIndicator != null)
                uiIndicator.SetActive(false);
        }
    }

    void ToggleLever()
    {
        if (isActivated) return;

        isActivated = true;

        Debug.Log("Palanca activada!");
        onLeverActivated?.Invoke();

        if (uiIndicator != null)
            uiIndicator.SetActive(false);
    }
}
