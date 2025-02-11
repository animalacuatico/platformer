using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAnims : MonoBehaviour
{
    private Animator animator;
    private platformMovement platformMovement;
    private SpriteRenderer spriteRenderer;
    public AudioClip AnimTestSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        platformMovement = GetComponent<platformMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        switch (platformMovement.GetPlayerState())
        {
            case PlayerState.IDLE:
                animator.SetBool("isWalking", false);
                break;
            case PlayerState.WALKING:
                animator.SetBool("isWalking", true);
                break;
            case PlayerState.JUMPING:
                break;
        }
        if (platformMovement.getDirection().x < 0) // Si el movimiento del jugador es hacia la izquierda (x<0)
        {
            spriteRenderer.flipX = true; // se gira a la izquierda.
        }
        else if (platformMovement.getDirection().x > 0) // si el movimiento del jugador es hacia la derecha (x>0)
        {
            spriteRenderer.flipX = false; // se mantiene en la derecha.
        }
    }
    public void PlayAnimTest(float volume)
    {
        audioManager.instance.PlayAudio(AnimTestSound, "testingsound", false, volume);
    }
}
