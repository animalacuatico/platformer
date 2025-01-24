using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deathzones : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<platformMovement>()) // Si detecta al jugador, resetea al jugador.
        {
            player.GetComponent<platformMovement>().ResetPlayerPos();
        }
    }
}
