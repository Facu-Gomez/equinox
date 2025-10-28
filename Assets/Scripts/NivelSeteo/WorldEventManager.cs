using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventManager : MonoBehaviour
{
    public static WorldEventManager Instance;

    private Dictionary<PlatformController.Mundo, List<Action>> eventosPendientes =
        new Dictionary<PlatformController.Mundo, List<Action>>()
        {
            { PlatformController.Mundo.Alba, new List<Action>() },
            { PlatformController.Mundo.Ocaso, new List<Action>() }
        };

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AgregarEvento(PlatformController.Mundo mundo, Action accion)
    {
        if (PlayerSwitcher.MundoActual == mundo)
        {
            accion.Invoke();
        }
        else
        {
            eventosPendientes[mundo].Add(accion);
        }
    }

    public void MundoCambiado(PlatformController.Mundo nuevoMundo)
    {
        if (eventosPendientes[nuevoMundo].Count > 0)
        {
            Debug.Log($"Ejecutando {eventosPendientes[nuevoMundo].Count} eventos pendientes de {nuevoMundo}");
            foreach (var e in eventosPendientes[nuevoMundo])
                e.Invoke();

            eventosPendientes[nuevoMundo].Clear();
        }
    }
}
