using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscena : MonoBehaviour
{
    [SerializeField] private String escena;

    public void CambiarEscena()
    {
        if (escena != null)
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            Debug.LogWarning("No se ha asignado ninguna escena.");
        }
    }
    public void OnButtonClick()
    {
        Debug.Log("Botón presionado, cambiando escena...");
        CambiarEscena();
    }
}
