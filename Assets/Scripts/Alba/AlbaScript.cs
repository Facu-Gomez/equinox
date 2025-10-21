using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerDash playerDash;
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 7f;                 
    public Transform groundCheck;                
    public float groundCheckRadius = 0.2f;       
    public LayerMask groundLayer;                

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        playerDash = GetComponent<PlayerDash>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerDash.IsDashing)
            return;
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
