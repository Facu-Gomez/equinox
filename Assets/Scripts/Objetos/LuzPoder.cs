using System;
using System.Collections;
using UnityEngine;

public class LuzPoder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asdasdasd");
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
         Debug.Log("asdasdasd");
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
    void OnCollisionStay2D()
    {
        Debug.Log("");


    }
   
}
