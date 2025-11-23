using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootDelay = 1.5f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootDelay)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = b.GetComponent<Bullet>();
        bullet.direction = Vector2.left;
        bullet.targetTag = "Player";
    }
}
