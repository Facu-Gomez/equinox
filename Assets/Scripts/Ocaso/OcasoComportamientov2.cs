using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OcasoComportamientov2 : MonoBehaviour
{
    [SerializeField]private bool Iluminado = false;
    [SerializeField] private float tiempoDeEspera = 4f;
    [SerializeField] private float tiempoRestante;
    [SerializeField] private int maxPuentes = 2;
    [SerializeField] private float tiempoParaDestruirElViejo = 3f;
    private Queue<PlataformaOcaso> puentes = new Queue<PlataformaOcaso>();
    public bool IluminadoPropiedad

    {
        get { return Iluminado; }
        set { Iluminado = value; }
    }
    void Update()
    {


        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.B) && tiempoRestante <= 0f)
        {
            PlataformaOcaso nuevaPlataforma = new PlataformaOcaso();
            ActivarBloque(nuevaPlataforma);
            tiempoRestante = tiempoDeEspera;
        }

    }

    public void ActivarBloque(PlataformaOcaso plataforma)
    {
        if (plataforma != null && plataforma.PubActivo == false && Iluminado == false)
        {
            if (puentes.Count >= maxPuentes)
            {
                Debug.Log("Ya ten�s el m�ximo de puentes (" + maxPuentes + "). Esper� a que alguno desaparezca.");
                return;
            }
            plataforma.Activar();
            puentes.Enqueue(plataforma);
        }
        if (puentes.Count >= 2)
        {
            StartCoroutine(DesactivarPuentes(puentes, tiempoParaDestruirElViejo));
        } 
    }
    private IEnumerator DesactivarPuentes(Queue<PlataformaOcaso> puentes, float delay)
    {
       
        yield return new WaitForSeconds(delay);

        if (puentes != null)
        {
            puentes.Peek().Deseactivar();
            PlataformaOcaso obj = puentes.Dequeue();
            Debug.Log("Puente desactivado: " + obj.name);
        }
    
        Debug.Log("Puentes en lista ahora: " + puentes.Count);

    }
}
