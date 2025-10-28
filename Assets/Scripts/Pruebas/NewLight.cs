using System.Collections;
using UnityEngine;

public class NewLight : MonoBehaviour
{
    private SpriteRenderer render;
    private Color colorOriginal;
    private Color colorIluminado = Color.yellow;
    
    [SerializeField] float duracionBrillo = 1f;
    
    
    void Start()
    {
        render = GetComponent<SpriteRenderer>();    
        
        if (render != null)
        {
            colorOriginal = render.color;

        }

    }
    

    private void OnMouseExit()
    {
        if (render != null)
            render.color = colorOriginal;
    }


    public void AccionDesdeJugador()
    {
        StartCoroutine(Brillar());
    }

    private IEnumerator Brillar() 
    {
    render.color = colorIluminado;
        yield return new WaitForSeconds(duracionBrillo);    
        render.color = colorOriginal;
    }

}
