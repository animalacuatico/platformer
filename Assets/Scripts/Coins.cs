using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound1, coinSound2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<platformMovement>()) // Si el jugador colisiona con la moneda
        {
            GameManager.instance.AddCoin(coinValue); // Se a�ade coinValue a las monedas.
            Debug.Log("Monedas: " + GameManager.instance.GetCoins()); // Imprimo en la consola la cantidad de monedas.
            int audios = RandomChance(); // Accedo al m�todo RandomChance para generar un 50% de posibilidad.
            if (audios == 0) // Si es 0, el primer audio
            {
                audioManager.instance.PlayAudio(coinSound1, "coinAudio1");
            }
            else // Si es 1, el segundo audio.
            {
                audioManager.instance.PlayAudio(coinSound2, "coinAudio2");
            }
            Destroy(gameObject); // Se destruye la moneda al tocarla el jugador
        }
    }
    private int RandomChance() // M�todo para generar un n�mero entre 0 y 1.
    {
        int rndNumber;
        rndNumber = Random.Range(0, 2);
        return rndNumber;
    }
}
