using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float velocidad = 2f;
    public int vida = 2;
    public Transform puntoA;
    public Transform puntoB;
    private bool haciaA = true;
    void Update()
    {
    Transform destino = haciaA ? puntoA : puntoB;
    transform.position = Vector2.MoveTowards(transform.position,
    destino.position, velocidad * Time.deltaTime);
    if (Vector2.Distance(transform.position, destino.position) < 0.1f)
    haciaA = !haciaA;
    }
    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        Destroy(gameObject);
    }
}
