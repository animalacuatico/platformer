using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAnims : MonoBehaviour
{
    private Animator animator;
    private platformMovement platformMovement;
    private SpriteRenderer spriteRenderer;
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
        if (platformMovement.getDirection().x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (platformMovement.getDirection().x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
