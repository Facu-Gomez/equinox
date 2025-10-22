using System.Collections;
using UnityEngine;

public class OcasoPared : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ocaso" && !other.gameObject.GetComponent<OcasoComportamientov2>().IluminadoPropiedad)
        {
            if (Input.GetKey(KeyCode.F))
            {
                StartCoroutine(IgnoreLayerTemporarily(LayerMask.NameToLayer("Characters"),1f));
            }
        }
    }
   private IEnumerator IgnoreLayerTemporarily(int layerToIgnore, float duration)
{
    
    Physics2D.IgnoreLayerCollision(gameObject.layer, layerToIgnore, true);
    yield return new WaitForSeconds(duration);
    Physics2D.IgnoreLayerCollision(gameObject.layer, layerToIgnore, false);
}
}
