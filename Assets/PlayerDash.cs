using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;
    private PlayerMove player;
    private float baseGravity;


    [Header("Dash")]
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float timeCanDash = 1f;

    private bool isDashing;
    private bool canDash = true;


    public bool IsDashing => isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMove>();
        baseGravity = rb.gravityScale;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Dash());


        }

    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(player.MovimientoHorizontal * dashForce,0);

        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        rb.gravityScale = baseGravity;
        
        yield return new WaitForSeconds(timeCanDash);
        canDash = true;


    }





}
