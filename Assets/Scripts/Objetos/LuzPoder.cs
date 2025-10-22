using System;
using System.Collections;
using UnityEngine;

public class LuzPoder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        switch (collision.gameObject.name)
            {
                case "Alba":
                    collision.gameObject.GetComponent<PlayerDash>().ActivarDash();
                    break;
                case "Ocaso":
                  collision.gameObject.GetComponent<OcasoComportamientov2>().IluminadoPropiedad = true;
                    break;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
         switch (collision.gameObject.name)
            {
                case "Alba":
                    collision.gameObject.GetComponent<PlayerDash>().DesactivarDash();
                    break;
                case "Ocaso":
                  collision.gameObject.GetComponent<OcasoComportamientov2>().IluminadoPropiedad = false;
                    break;
            }
    }
}
