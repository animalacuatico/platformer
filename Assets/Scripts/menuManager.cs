using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPrograms : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadPlatformer()
    {
        SceneManager.LoadScene("Platforming");
    }
    
}
