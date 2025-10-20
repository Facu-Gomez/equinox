using UnityEngine;

public class InteraccionCaja : MonoBehaviour
{
    public LayerMask capaCaja;
    public KeyCode teclaAccion = KeyCode.Q;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f,capaCaja);

        if (Input.GetKeyDown(teclaAccion))
        {
            if (hit.collider != null)
            {
                NewBox caja = hit.collider.GetComponent<NewBox>();

                if (caja != null) 
                {
                    caja.AccionDesdeJugador();
                }

                NewLight luz = hit.collider.GetComponent<NewLight>();
                if (luz != null)
                {
                    luz.AccionDesdeJugador();
                    return;
                }

            }
        
        
        
        
        
        }


    }
}
