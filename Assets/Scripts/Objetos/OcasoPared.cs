using System;
using System.Collections;
using UnityEngine;

public class OcasoPared : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D hitbox;
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionExit2D(Collision2D collision)
    {
          
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.name == "Ocaso" && !other.gameObject.GetComponent<OcasoComportamientov2>().IluminadoPropiedad)
        {
          
            Debug.Log(Input.GetKey(KeyCode.F));
            if (Input.GetKey(KeyCode.F))
            {
                StartCoroutine(NoColisiona(other.gameObject.GetComponent<BoxCollider2D>(),1f));
            }
        }
    }

    
    private IEnumerator NoColisiona(Collider2D Jugador, float duration)
{

        Physics2D.IgnoreCollision(hitbox,Jugador, true);
        Debug.Log("Ignorando");
    yield return new WaitForSeconds(duration);
    Physics2D.IgnoreCollision(hitbox,Jugador, false);
}
}
