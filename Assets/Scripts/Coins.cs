using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<platformMovement>())
        {
            GameManager.instance.AddCoin(coinValue);
            Debug.Log("Monedas: " + GameManager.instance.GetCoins());
            Destroy(gameObject);
        }
    }
}
