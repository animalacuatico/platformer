using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound1, coinSound2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<platformMovement>())
        {
            GameManager.instance.AddCoin(coinValue);
            Debug.Log("Monedas: " + GameManager.instance.GetCoins());
            RandomChance();
            if (RandomChance())
            Destroy(gameObject);
            
        }
    }
    private int RandomChance()
    {
        int rndNumber;
        rndNumber = Random.Range(0, 2);
        return rndNumber;
    }
}
