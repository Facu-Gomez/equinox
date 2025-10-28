using UnityEngine;

public class NewBox : MonoBehaviour
{
    public GameObject newBox;
    public Vector2 offset = new Vector2(2f, 0);






    

    public void AccionDesdeJugador()
    {
        CrearNuevaCaja();
    }

    private void CrearNuevaCaja()
    {

        if (newBox != null)
        {
            Vector2 nuevaPosicion = (Vector2)transform.position + offset;
            Instantiate(newBox, nuevaPosicion, Quaternion.identity);
        }  
    
    
    
}


}
