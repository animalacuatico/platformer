using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonPrograms : MonoBehaviour
{
    public void LoadMenuScene()
    {
        GameManager.instance.ChangeScene("Menu");
    }
    public void LoadPlatformer()
    {
        GameManager.instance.ChangeScene("Platforming");
    }
    //private void start()
    //{
    //    GameManager.instance.ChangeScene("Menu");
    //    GameManager.instance.ChangeScene("Platforming");
    //}
}
