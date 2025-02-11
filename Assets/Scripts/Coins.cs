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
            int audios = RandomChance();
            if (audios == 0)
            {
                audioManager.instance.PlayAudio(coinSound1, "coinAudio1");
            }
            else
            {
                audioManager.instance.PlayAudio(coinSound2, "coinAudio2");
            }
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
