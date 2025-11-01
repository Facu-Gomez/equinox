using System;
using System.Collections;
using UnityEngine;

public class LuzPoder : MonoBehaviour
{
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
