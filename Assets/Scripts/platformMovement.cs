using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 dirVector;
    public float speed = 5, jumpForce = 5, sphereRadius = 0.15f;
    private bool isJumping = false;
    public LayerMask groundMask;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        dirVector = new Vector2(Input.GetAxis("Horizontal"), 0); // Movimiento horizontal.
        Jump();
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(dirVector.x * speed, rb2D.velocity.y); // Para conservar la gravedad en y.
        ApplyJump();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
        }
    }
    void ApplyJump()
    {
        if (isJumping)
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





    // Esta es una forma de hacer para que no pueda saltar en el aire.
    // private bool canJump;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    canJump = true;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    canJump = false;
    //}
}
