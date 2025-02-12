using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 dirVector;
    public float enemySpeed = 2;
    public LayerMask playerMask;
    public GameObject enemy, assignedPlayer;
    private Vector2 xpos;
    public AudioClip enemyDeathSound;
    private float enemyPosX;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enemyPosX = assignedPlayer.transform.position.x;
        xpos = new Vector2(enemyPosX, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, xpos, enemySpeed * Time.deltaTime);
        if (CheckSides())
        {
            assignedPlayer.GetComponent<platformMovement>().ResetPlayerPos(); 
            // S� que en la tarea pon�a que se deb�a de destruir el player, pero para que no tenga que resetear todo el rato la escena he hecho que se resetee su posici�n.
            // Para que el jugador se destruya cuando el enemigo lo toca por los lados, descomenta la l�nea inferior en este m�todo.
            // assignedPlayer.GetComponent<platformMovement>().KillPlayer();
        }
        if (CheckTop())
        {
            audioManager.instance.PlayAudio(enemyDeathSound, "enemyDeathSounds"); // Si el jugador toca al enemigo por arriba, pone el sonido de muerte y luego se destruye el enemigo.
            Destroy(gameObject);
        }
    }
    bool CheckSides()
    {
        // Castea un RAYCAST, desde la posici�n del enemigo, hacia la izquierda, m�x distancia 0.55f, y si detecta el playerMask Y castea otro, desde la posici�n del enemigo, hacia la derecha, m�x distancia 0.55f, y si detecta el playerMask.
        bool outcome = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, playerMask) || Physics2D.Raycast(transform.position, Vector2.right, 0.55f, playerMask);
        return outcome;
    }
    bool CheckTop()
    {
        // El mismo RAYCAST, desde la posici�n del enemigo, hacia arriba, m�x distancia 0.55f, y si detecta el playerMask
        bool outcome = Physics2D.Raycast(transform.position, Vector2.up, 0.55f, playerMask);
        return outcome;
    }

}
