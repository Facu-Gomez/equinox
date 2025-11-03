using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;
    [SerializeField]private PlayerMove player;
    private float baseGravity;


    [Header("Dash")]
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float timeCanDash = 1f;

    private bool isDashing;
    [SerializeField]private bool canDash = false;


    public bool IsDashing => isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
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
       if (rb.GetRelativePointVelocity(Vector2.zero) != Vector2.zero && canDash)
        {

            float move = Input.GetAxisRaw("Horizontal");
            Debug.Log(" " + move + " ");
            
    
            Debug.Log(" " + dashForce);
       
            isDashing = true;
            canDash = false;
            rb.gravityScale = 0f;

            rb.linearVelocity = new Vector2(move * player.moveSpeed * dashForce, 0f);

            yield return new WaitForSeconds(dashingTime);
            isDashing = false;
            rb.gravityScale = baseGravity;

            yield return new WaitForSeconds(timeCanDash);
            canDash = true;

        }




    }
public void ActivarDash()
    {
        canDash = true;
       
    }
public void DesactivarDash()
    {
        canDash = false;

    }



}
