using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform target; // El personaje (Player)

    [Header("Configuraci�n")]
    public float smoothSpeed = 5f; // Velocidad de suavizado
    public Vector3 offset;         // Desplazamiento de la c�mara respecto al jugador

    void LateUpdate()
    {
        if (target == null) return;

        // Posici�n deseada con el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolaci�n suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Aplicar posici�n
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
