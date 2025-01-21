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
        }
        if (CheckTop())
        {
            Destroy(gameObject);
            assignedPlayer.GetComponent<platformMovement>().ApplyJump();
        }
    }
    bool CheckSides()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, playerMask) || Physics2D.Raycast(transform.position, Vector2.right, 0.55f, playerMask);
        return outcome;
    }
    bool CheckTop()
    {
        bool outcome = Physics2D.Raycast(transform.position, Vector2.up, 0.55f, playerMask);
        return outcome;
    }

}
