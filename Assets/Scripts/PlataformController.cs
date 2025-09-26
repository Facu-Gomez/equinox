using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float velocidadBajada = 2f;
    public float distanciaBajada = 5f;

    private bool bajar = false;
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;

    void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = posicionInicial + Vector3.down * distanciaBajada;
    }

    void Update()
    {
        if (bajar)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidadBajada * Time.deltaTime);
        }
    }

    public void BajarPlataforma()
    {
        bajar = true;
    }
}
