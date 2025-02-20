using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum InterfaceVariable { TIME, COINS_GAME };

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // static hace que s�lo pueda existir una copia de la variable GameManager en todo el c�digo
    private float currentGameTime = 0;
    private float coins = 0;
    void Awake()
    {
       if (!instance) // instance == null es lo mismo
       {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para que no se destruya este objeto cuando cambia la escena.
       }
       else
       {
            Destroy(gameObject);
       }
    }
    void Update()
    {
        currentGameTime += Time.deltaTime;
    }
    public float GetTime() // M�todo para saber el tiempo que lleva la aplicaci�n activa.
    {
        return currentGameTime;
    }
    public void AddCoin(int value) // M�todo para a�adir "coins", con una variable value.
    {
        coins += value;
    }
    public float GetCoins() // M�todo para obtener la cantidad de "coins" actuales.
    {
        return coins;
    }
    public void RemoveCoin(int value) // M�todo para remover "coins", con una variable value.
    {
        coins -= value;
    }
    public string GetCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
