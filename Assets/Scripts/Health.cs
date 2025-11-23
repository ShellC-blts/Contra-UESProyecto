using UnityEngine;

public class Health : MonoBehaviour
{
    public int life = 5;

    public void TakeDamage(int dmg)
    {
        life -= dmg;
        if (life <= 0) Destroy(gameObject);
    }
}
