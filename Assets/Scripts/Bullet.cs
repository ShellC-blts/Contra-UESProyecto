using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public Vector2 direction;
    public string targetTag;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            col.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
