using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // Para insertar un sonido: Coger sonido, meterlo en Sounds, create empty, meter Audio source al objeto empty, ponerlo en loop, tocar las propiedades, y si es audio 3d, hacerlo hijo del dueño de ese audio.
    // Si el sonido no está en loop, cuando deje de sonar he de destruirlo.
    public static audioManager instance;
    private List<AudioSource> sounds;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sounds = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f) // Crear este método que sirve para todos los scripts.
    {
        // 1. Crear empty:
        GameObject nObject = new GameObject();
        // 2. Ponerle nombre:
        nObject.name = gameObjectName;
        // 3. Añadir el audioSource
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>();
        // 4. Arrastrar el audioClip
        audioSourceComponent.clip = clip;
        // 5. Seteamos el loop
        audioSourceComponent.loop = isLoop;
        // 6. Regular propiedades del audio, como volumen, pitch.. etc. Pero sólo tenemos volúmen en este.
        audioSourceComponent.volume = volume;
        // 7. Añadimos el objeto a la lista
        sounds.Add(audioSourceComponent);
        // 8. Que suene.
        audioSourceComponent.Play();
        // 9. Cuando deje de sonar, hay que destruirlo, para que el rendimiento no empeore.
        StartCoroutine(WaitForAudio(audioSourceComponent));
        return audioSourceComponent;
    }
    private IEnumerator WaitForAudio(AudioSource source) // Un método que destruye el objeto del sonido creado una vez termina.
    {
        if (source.loop)
        {
            yield return null;
        }
        else
        {
        // Esperamos mientras el audio este sonando.
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }
        // Cuando el audio deje de sonar, destruirlo.
        Destroy(source.gameObject);
        }
    }
}
