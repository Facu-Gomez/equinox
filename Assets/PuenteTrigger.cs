using UnityEngine;

public class PuenteTrigger : MonoBehaviour
{
    public GameObject puente;
    [SerializeField] int cantidad = 2;
    [SerializeField] Vector3 offset = new Vector3(1,0,0);

    private bool puenteCreado = false   ; 



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entró: " + collision.name);

        if (collision.CompareTag("Player2") && !puenteCreado)
        {
            //CrearPuente():
            puenteCreado = true; 
        }
    }

    private void CrearPuente()
    {
        Vector3 inicio = transform.position;

        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicion = inicio + offset * i;
            Instantiate (puente, posicion, Quaternion.identity) ;
        }
    }

}
