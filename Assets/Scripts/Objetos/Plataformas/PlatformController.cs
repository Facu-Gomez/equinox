using UnityEngine;

public class PlatformController : MonoBehaviour
{
    //Controlador de una plataforma general altamente personalizable
    public enum DireccionMovimiento { Horizontal, Vertical }
    public enum Mundo { Alba, Ocaso }

    [Header("Configuración de movimiento")]
    public DireccionMovimiento direccion = DireccionMovimiento.Horizontal;
    public float distancia = 3f;
    public float velocidad = 2f;
    public bool idaYVuelta = false;
    public bool estaActiva = false;
    public Mundo mundoDeEsta;

    [Header("Requiere ambos jugadores?")]
    public bool requireBothPlayers = false;
    public Transform jugadorAlba;
    public Transform jugadorOcaso;
    public float rangoDeteccion = 1f;

    private Vector3 posicionInicial;
    private bool moviendoHaciaDestino = true;
    private bool ambosSobre = false;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!estaActiva)
            return;

        if (requireBothPlayers)
        {
            ambosSobre = EstanAmbosSobre();
            if (!ambosSobre)
                return;
        }

        MoverPlataforma();
    }

    void MoverPlataforma()
    {
        Vector3 destino;

        if (direccion == DireccionMovimiento.Horizontal)
            destino = posicionInicial + new Vector3(distancia, 0, 0);
        else
            destino = posicionInicial + new Vector3(0, distancia, 0);

        if (moviendoHaciaDestino)
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            if (idaYVuelta)
                moviendoHaciaDestino = false;
            else
                estaActiva = false;
        }

        if (idaYVuelta && Vector3.Distance(transform.position, posicionInicial) < 0.01f && !moviendoHaciaDestino)
        {
            moviendoHaciaDestino = true;
        }
    }

    bool EstanAmbosSobre()
    {
        if (jugadorAlba == null || jugadorOcaso == null)
            return false;

        bool albaSobre = Vector2.Distance(jugadorAlba.position, transform.position) < rangoDeteccion;
        bool ocasoSobre = Vector2.Distance(jugadorOcaso.position, transform.position) < rangoDeteccion;

        return albaSobre && ocasoSobre;
    }

    public void Activar()
    {
        estaActiva = true;
    }

    public void Detener()
    {
        estaActiva = false;
    }
}
