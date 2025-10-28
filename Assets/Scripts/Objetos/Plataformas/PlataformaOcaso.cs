using UnityEditor.Callbacks;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlataformaOcaso : MonoBehaviour
{
    //Este script se le coloca a la plataforma que ocaso genera ,para poder activarla y desactivarla
    //Aclaracion:No se desactiva el objeto,ya que si se desactivara completamente,se nesesitaria de otro script para activarlo,con referencia a este constantemente
        [SerializeField]private OcasoComportamientov2 ocasoComportamientov2;
    private Rigidbody2D rb;
    private BoxCollider2D hitbox;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private bool activo;
    public bool PubActivo
    {
        get { return activo; }
        set { activo = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Activar()
    {
        hitbox.includeLayers = LayerMask.GetMask("Characters");
          hitbox.excludeLayers = LayerMask.GetMask();
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        Debug.Log("Plataforma activada: " + gameObject.name);
    }
    public void Deseactivar()
    {
        hitbox.excludeLayers = LayerMask.GetMask("Characters");
         hitbox.includeLayers = LayerMask.GetMask();
        spriteRenderer.color = Color.darkRed;
    }
    
    void OnMouseDown()
    {
       ocasoComportamientov2.ActivarBloque(this);
        
    }

}
