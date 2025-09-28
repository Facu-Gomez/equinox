using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
    public enum Mundo { Alba, Ocaso }
    public Mundo mundoDeEsta;

    public float bajarDistancia = 3.5f;
    public float velocidad = 2f;

    private bool debeBajar = false;
    private bool estaBajando = false;

    void Update()
    {
        if (debeBajar && PlayerSwitcher.MundoActual == mundoDeEsta && !estaBajando)
        {
            StartCoroutine(Bajar());
        }
    }

    public void BajarPlataforma()
    {
        debeBajar = true;
    }

    private IEnumerator Bajar()
    {
        estaBajando = true;
        Vector3 inicio = transform.position;
        Vector3 destino = inicio + Vector3.down * bajarDistancia;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * velocidad / bajarDistancia;
            transform.position = Vector3.Lerp(inicio, destino, t);
            yield return null;
        }
    }
}
