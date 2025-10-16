using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public enum DireccionMovimiento { Horizontal, Vertical }
    public enum Mundo { Alba, Ocaso }

    [Header("Movimiento")]
    public DireccionMovimiento direccion = DireccionMovimiento.Vertical;
    public float distancia = 3f;
    public float velocidad = 2f;

    [Header("Comportamiento")]
    [Tooltip("Si está activado, la plataforma irá y volverá indefinidamente. Si no, se moverá una vez y se detendrá.")]
    public bool idaYVuelta = true;

    [Header("Mundo de esta plataforma")]
    public Mundo mundoDeEsta;

    private Vector3 posicionInicial;
    private Vector3 posicionDestino;
    private bool moviendo = false;
    private bool yendo = true;

    void Start()
    {
        posicionInicial = transform.position;
        posicionDestino = direccion == DireccionMovimiento.Horizontal
            ? posicionInicial + Vector3.right * distancia
            : posicionInicial + Vector3.up * distancia;
    }

    void Update()
    {
        if (moviendo)
            Mover();
    }

    void Mover()
    {
        Vector3 destino = yendo ? posicionDestino : posicionInicial;
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            if (idaYVuelta)
            {
                yendo = !yendo; // cambia de dirección
            }
            else
            {
                moviendo = false; // se detiene al llegar
            }
        }
    }

    /// <summary>
    /// Activa el movimiento de la plataforma.
    /// </summary>
    public void Activar()
    {
        moviendo = true;
    }

    /// <summary>
    /// Detiene el movimiento de la plataforma manualmente.
    /// </summary>
    public void Detener()
    {
        moviendo = false;
    }

    /// <summary>
    /// Resetea la posición a la inicial (opcional, útil para debugging).
    /// </summary>
    public void ReiniciarPosicion()
    {
        transform.position = posicionInicial;
        moviendo = false;
        yendo = true;
    }
}
