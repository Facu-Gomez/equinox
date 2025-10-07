using System;
using UnityEngine;

public class CambiaPantalla : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] GameObject pantallaCarga;
    [SerializeField] GameObject MundoOcaso;
    [SerializeField] GameObject MundoAlba;
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
        MundoAlba.SetActive(false);
        MundoOcaso.SetActive(false);
        pantallaCarga.SetActive(true);
        SetMainCamera(camara);
        Debug.Log("El jugador ha caido en la zona de caida.");
        // Aquí puedes agregar la lógica que deseas ejecutar cuando el jugador cae en la zona de caída.
void SetMainCamera(Camera nuevaCamara)
{
    if (Camera.main != null)
        Camera.main.gameObject.SetActive(false);

    nuevaCamara.gameObject.SetActive(true);
    nuevaCamara.tag = "MainCamera";
}

    }
    
}
