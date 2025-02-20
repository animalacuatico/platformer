using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum InterfaceVariable { TIME, COINS_GAME };

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // static hace que sólo pueda existir una copia de la variable GameManager en todo el código
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
    public float GetTime() // Método para saber el tiempo que lleva la aplicación activa.
    {
        return currentGameTime;
    }
    public void AddCoin(int value) // Método para añadir "coins", con una variable value.
    {
        coins += value;
    }
    public float GetCoins() // Método para obtener la cantidad de "coins" actuales.
    {
        return coins;
    }
    public void RemoveCoin(int value) // Método para remover "coins", con una variable value.
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
