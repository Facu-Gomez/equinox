using UnityEngine;

public class OcasoScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float salto;

    [SerializeField] private float movimientoHorizontal;
    private Rigidbody2D rb;
    public GameObject Ocaso;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ocaso.AddComponent<OcasoScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        Ocaso.transform.Translate(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);
    }

   
}
