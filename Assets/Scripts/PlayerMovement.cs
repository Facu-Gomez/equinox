using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 8f;
    
    private Rigidbody2D rb;
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        Player.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);
        //rb.velocity = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);
    }

}
