using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public AudioClip music;
    void Start()
    {
        audioManager.instance.PlayAudio(music, "backgroundMusic", true); // Poner la m�sica de fondo en true para que sea un loop constante.
    }
}
