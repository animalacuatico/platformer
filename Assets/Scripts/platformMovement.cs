using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState { IDLE, WALKING, JUMPING }
public class platformMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 dirVector;
    public float speed = 5, jumpForce = 7, sphereRadius = 0.15f, jumpingVolume = 3;
    public AudioClip jumpingClip;
    private bool isJumping = false;
    [SerializeField]
    private PlayerState currentstate;

    public LayerMask groundMask;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        dirVector = new Vector2(Input.GetAxis("Horizontal"), 0); // Movimiento horizontal.
        if (dirVector.magnitude == 0) // Calculando cuanto mide el vector del jugador con el .magnitude, se comprueba si hay movimiento o no.
        {
            currentstate = PlayerState.IDLE; // Se cambia el estado del jugador a IDLE.
        }
        else
        {
            currentstate = PlayerState.WALKING; // Si no, se cambia el estado del jugador a WALKING.
        }
        Jump(); // Para que todo el rato esté detectando si se presiona espacio.
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(dirVector.x * speed, rb2D.velocity.y); // Para conservar la gravedad en y.
        ApplyJump(); // Para aplicar el salto, cuando "isJumping" sea verdadero.
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) // Si está presionando saltar Y está en el suelo, siendo detectado mediante el método IsGrounded.
        {
            isJumping = true; // Activa isJumping.
            currentstate = PlayerState.JUMPING; // Cambia el estado del jugador a JUMPING.
            audioManager.instance.PlayAudio(jumpingClip, "jumpSound");
        }
    }
    public void ApplyJump()
    {
        if (isJumping) // Si isJumping es verdadero, se aplica el salto.
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0); // Para que siempre salte con la misma fuerza y la gravedad no le afecte.
            rb2D.AddForce(Vector2.up * jumpForce * rb2D.gravityScale, ForceMode2D.Impulse); // Aplicamos rb2D.gravityScale al final para asegurarnos que supera la gravedad. Se aplica el ForceMode2D.Impulse
            isJumping = false;
        }
    }
    // IsGrounded() está bien para apuntes.
    private bool IsGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), sphereRadius, groundMask); // Se "castea" un círculo desde los "pies" del jugador.
        return colliders != null; // El círculo que hemos casteado, no está en contacto con el suelo.
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), sphereRadius);
    }
    // Métodos para usar en otros scripts
    public void ResetPlayerPos() // Un método para resetear la posición del jugador al comienzo.
    {
        gameObject.transform.position = new Vector2(-10.52f, -1.49f);
    }
    public PlayerState GetPlayerState() // Método para obtener el estado del jugador, si se está moviendo o no, saltando.. etc.
    {
        return currentstate;
    }
    public Vector2 getDirection() // Método para obtener la dirección del jugador.
    {
        return dirVector;
    }
    public void KillPlayer() // Método que "mata" al jugador.
    {
        Destroy(gameObject);
    }
}
