using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OcasoScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    
    [SerializeField] private float movimientoHorizontal;
    [SerializeField] private float tiempoDeEspera = 4f;
    [SerializeField] private float tiempoRestante;
    
    
    
    private Rigidbody2D rb;
    public GameObject Ocaso;

    public GameObject Puente;


    [SerializeField] private int maxPuentes = 2;
    [SerializeField] private float tiempoParaDestruirElViejo = 3f;

    private List<GameObject> puentes = new List<GameObject>();  


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (tiempoRestante > 0) 
        {
        tiempoRestante -= Time.deltaTime;   
        }
        
        
        if (Input.GetKeyDown(KeyCode.B) && tiempoRestante  <= 0f)
        {
            CrearBloque();
            tiempoRestante = tiempoDeEspera;
        }

    }

    private void Move()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        Ocaso.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);
    }

    private void CrearBloque()
    {
        if (Puente == null)
        {
            Debug.LogError("PuentePrefab NO asignado en el Inspector.");
            return;
        }

        if (puentes.Count >= maxPuentes)
        {
            Debug.Log("Ya ten�s el m�ximo de puentes (" + maxPuentes + "). Esper� a que alguno desaparezca.");
            return;
        }






        Vector3 posicion = new Vector3(transform.position.x, transform.position.y - 1f, 0);
        GameObject nuevo = Instantiate(Puente, posicion, Quaternion.identity);
        puentes.Add(nuevo);
        Debug.Log("Puente creado: " + nuevo.name + " (puentes en lista: " + puentes.Count + ")");

        if (puentes.Count == 2)
        {
            StartCoroutine(DestruirYRemover(puentes[0], tiempoParaDestruirElViejo));
        } 
    }


        private IEnumerator DestruirYRemover(GameObject obj, float delay)
    {
       
        yield return new WaitForSeconds(delay);

        if (obj != null)
        {
            Destroy(obj);
            Debug.Log("Puente destruido: " + obj.name);
        }
        puentes.Remove(obj);
        Debug.Log("Puentes en lista ahora: " + puentes.Count);

    }



        



    }


   

