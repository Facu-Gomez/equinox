using UnityEditor.SearchService;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float movimiento = 8f;
    
    

    private Rigidbody2D rb;
    GameObject Player;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float Velocidad = Input.GetAxisRaw("Horizontal");

        Player.transform.Translate( movimiento * Time.deltaTime, 0, 0);

      


    }
}
