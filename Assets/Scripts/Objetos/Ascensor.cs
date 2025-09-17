using UnityEngine;

public class Ascensor : MonoBehaviour, IDActivable
{
   [SerializeField] private bool estaActivo = false;
   [SerializeField] private int paradaActual = 1;
    private int direccion = 1; 
    [SerializeField] private Transform[] paradas;
[SerializeField] private float velocidad = 2f;


    public void Activar()
    {
        estaActivo = true; 
        Debug.Log ("Ascensor activado");

    }
    void Update()
    {
        if (estaActivo)
        {
            Transform objetivo = paradas[paradaActual];
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

            if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
            {
                paradaActual += direccion;
            // Cambia dirección si es necesario
            if (paradaActual >= paradas.Length)
            {
                paradaActual = paradas.Length - 2;
                direccion = -1;
            }
            else if (paradaActual < 0)
            {
                paradaActual = 1;
                direccion = 1;
            }

                
                
                estaActivo = false;
            }
        }
    }

}

  
  
