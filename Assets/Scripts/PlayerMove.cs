using UnityEditor.SearchService;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocidad = 8f;

    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo;
    private PlayerDash playerDash;
    
    private float movimientoHorizontal;
    public float MovimientoHorizontal => movimientoHorizontal;

    private Rigidbody2D rb;
    public GameObject Player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       playerDash = GetComponent<PlayerDash>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        Player.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);

        if (!playerDash.IsDashing)
        {

        
        Jump();
        }


        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down, longitudRaycast,capaSuelo);
        enSuelo = hit.collider != null;

       
    }

    private void FixedUpdate()
    {

        if (!playerDash.IsDashing) 
        { 
        Move();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

    private void Jump()
    {
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))

        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        Player.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);
    }


}



