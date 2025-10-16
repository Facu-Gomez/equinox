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

    [Tooltip("Si está activada, la plataforma comenzará a moverse al iniciar el juego.")]
    public bool estaActiva = false;

    [Tooltip("Define a qué mundo pertenece esta plataforma.")]
    public Mundo mundoDeEsta;

    private Vector3 posicionInicial;
    private Vector3 posicionDestino;
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
        if (estaActiva)
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
                yendo = !yendo;
            }
            else
            {
                estaActiva = false; // se detiene si no es ida y vuelta
            }
        }
    }

    /// <summary>
    /// Activa el movimiento de la plataforma.
    /// </summary>
    public void Activar()
    {
        estaActiva = true;
    }

    /// <summary>
    /// Detiene el movimiento de la plataforma manualmente.
    /// </summary>
    public void Detener()
    {
        estaActiva = false;
    }

    /// <summary>
    /// Resetea la posición a la inicial (opcional, útil para debugging).
    /// </summary>
    public void ReiniciarPosicion()
    {
        transform.position = posicionInicial;
        estaActiva = false;
        yendo = true;
    }
}
