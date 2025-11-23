using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float velocidad = 2f;
    public int vida = 3;

    public Transform objetivo;

    void Update()
    {
        if (objetivo != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                objetivo.position,
                velocidad * Time.deltaTime
            );
        }
    }

    public void RecibirDaño(int dmg)
    {
        vida -= dmg;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
