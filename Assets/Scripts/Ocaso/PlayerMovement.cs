using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 7f;                 
    public Transform groundCheck;                
    public float groundCheckRadius = 0.2f;       
    public LayerMask groundLayer;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip pasoSound;
    public AudioClip saltoSound;
    public float pasoInterval = 0.4f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float pasoTimer = 0f;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   protected virtual void Update()
    {
       
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("movement", move* moveSpeed);

        if (move < 0)
        {
            transform.localScale = new Vector3(-0.169708f, 0.164098f, 1);

        }
        if (move > 0) 
        {
            transform.localScale = new Vector3(0.169708f, 0.164098f, 1);
        
        
        }




        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Mathf.Abs(move) > 0.1f)
        {
            pasoTimer -= Time.deltaTime;
            if (pasoTimer <= 0f)
            {
                audioSource.PlayOneShot(pasoSound);
                pasoTimer = pasoInterval;
            }
        }



        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource.PlayOneShot(saltoSound);  
        }
        animator.SetBool("isGrounded", isGrounded);
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
