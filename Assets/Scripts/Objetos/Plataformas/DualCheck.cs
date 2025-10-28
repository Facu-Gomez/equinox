using UnityEngine;

public class DualCheck : MonoBehaviour
{
    //Se le coloca a un objeto vacio,con 2 referencias a 2 plataformas en distintos mundos,cuando ambos personajes se postran sobre las 2 plataformás
    // y la fuente de energia esta cargada,ambas plataformas se activan y comienzan a moverse
    [Header("Referencias")]
    public ChargeSource fuenteDeEnergia;
    public PlatformController plataformaAlba;
    public PlatformController plataformaOcaso;
    public Transform jugadorAlba;
    public Transform jugadorOcaso;

    [Header("Configuración")]
    public float rangoDeteccion = 1f;

    private bool albaSobre = false;
    private bool ocasoSobre = false;
    private bool plataformasActivas = false;
    private bool energiaDisponible = false;

    void Update()
    {
        if (fuenteDeEnergia == null || plataformaAlba == null || plataformaOcaso == null)
            return;

        energiaDisponible = GetEnergiaDisponible();

        if (energiaDisponible && !AmbosJugadoresSobre())
        {
            if (plataformasActivas)
            {
                plataformaAlba.Detener();
                plataformaOcaso.Detener();
                plataformasActivas = false;
            }
            return;
        }

        if (!energiaDisponible)
        {
            if (plataformasActivas)
            {
                plataformaAlba.Detener();
                plataformaOcaso.Detener();
                plataformasActivas = false;
            }
            return;
        }

        if (energiaDisponible && AmbosJugadoresSobre())
        {
            if (!plataformasActivas)
            {
                plataformaAlba.Activar();
                plataformaOcaso.Activar();
                plataformasActivas = true;
            }
        }
    }

    bool AmbosJugadoresSobre()
    {
        albaSobre = Vector2.Distance(jugadorAlba.position, plataformaAlba.transform.position) < rangoDeteccion;
        ocasoSobre = Vector2.Distance(jugadorOcaso.position, plataformaOcaso.transform.position) < rangoDeteccion;
        return albaSobre && ocasoSobre;
    }

    private bool GetEnergiaDisponible()
    {
        var field = typeof(ChargeSource).GetField("isFullyCharged",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field != null)
            return (bool)field.GetValue(fuenteDeEnergia);

        return false;
    }
}
