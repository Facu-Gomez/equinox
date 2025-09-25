using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;  // Fuerza del salto
    private bool enSuelo = false;    // Para saber si puede saltar

    private Rigidbody2D rb;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        Player.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);

        // Salto con W (solo si está en el suelo)
        if (Input.GetKeyDown(KeyCode.W) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
    }

    // Detectar si el jugador toca el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) // asegúrate de que tu suelo tenga el tag "Suelo"
        {
            enSuelo = true;
        }
    }
}
