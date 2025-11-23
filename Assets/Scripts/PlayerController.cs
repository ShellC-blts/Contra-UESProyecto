using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody2D rb;
    private bool enSuelo = false;

    [Header("Vida del Jugador")]
    public int vidas = 3;

    [Header("Sistema de Disparo")]
    public GameObject proyectilLaser;
    public GameObject proyectilFuego;
    public Transform puntoDisparo;
    private WeaponManager wm;

    [Header("Golpe Cuerpo a Cuerpo")]
    public Transform puntoGolpe;
    public float rangoGolpe = 0.5f;
    public int dañoGolpe = 1;
    public LayerMask capaEnemigos;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        wm = GetComponent<WeaponManager>();
    }

    void Update()
    {
        // Movimiento
        float movimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidad, rb.velocity.y);

        anim.SetFloat("Velocidad", Mathf.Abs(movimiento));
        anim.SetBool("EnSuelo", enSuelo);

        // Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proyectil =
                wm.ObtenerArmaActual() == proyectilLaser
                ? proyectilLaser
                : proyectilFuego;

            Instantiate(proyectil, puntoDisparo.position, Quaternion.identity);
        }

        // Golpe cuerpo a cuerpo
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Golpe");

            Collider2D enemigo = Physics2D.OverlapCircle(
                puntoGolpe.position,
                rangoGolpe,
                capaEnemigos
            );

            if (enemigo != null)
            {
                enemigo.GetComponent<EnemyAI>().RecibirDaño(dañoGolpe);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
            enSuelo = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
            enSuelo = false;
    }

    public void RecibirDaño(int dmg)
    {
        vidas -= dmg;

        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoGolpe.position, rangoGolpe);
    }
}
