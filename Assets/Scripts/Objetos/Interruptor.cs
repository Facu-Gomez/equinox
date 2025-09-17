using System;
using Unity.VisualScripting;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    private BoxCollider2D hitbox;
    [SerializeField] public MonoBehaviour objetoActivable;
     private bool jugadorDentro = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hitbox = GetComponent<BoxCollider2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (jugadorDentro && Input.GetKeyDown(KeyCode.E))
        {
            if (objetoActivable is IDActivable activable)
            {
                Debug.Log("Activating object");
                activable.Activar();
            }
        }
    }
    

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }

    private void Activar()
    { }
}

