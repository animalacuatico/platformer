using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public AudioClip music;
    public float MusicVolume = 1;
    void Start()
    {
        audioManager.instance.PlayAudio(music, "backgroundMusic");
    }
}
