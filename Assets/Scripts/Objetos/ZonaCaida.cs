using System;
using UnityEngine;

public class ZonaCaida : MonoBehaviour
{
    CambioEscena cambioEscena;
    void Start()
    {
        cambioEscena = GetComponent<CambioEscena>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        cambioEscena.CambiarEscena();
            Debug.Log("El jugador ha caido en la zona de caida.");
            // Aquí puedes agregar la lógica que deseas ejecutar cuando el jugador cae en la zona de caída.
        
    }
}
