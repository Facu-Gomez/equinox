using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsHub : MonoBehaviour
{
    public string nombreEscena;
    private KeyCode teclaInteraccion = KeyCode.F;

    private bool jugadorEnRango = false;

    private void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(teclaInteraccion))
        {
            if (!string.IsNullOrEmpty(nombreEscena))
            {
                SceneManager.LoadScene(nombreEscena);
            }
            else
            {
                Debug.LogWarning($"[PuertaNivel] No se asignó ninguna escena en {gameObject.name}");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorEnRango = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorEnRango = false;
    }
}
