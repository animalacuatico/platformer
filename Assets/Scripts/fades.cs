using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class fades : MonoBehaviour
{
    private SpriteRenderer rend;
    public float coroutineTime = 0.1f, speed = 8;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut() // Corrutina.
    {
        for (float alpha = 1; alpha > 0; alpha -= speed * Time.deltaTime)
        {
            Color currentColor = rend.color;
            currentColor.a = alpha;
            rend.color = currentColor;
            yield return new WaitForSeconds(coroutineTime);
        }
        StartCoroutine(FadeIn()); // Recursión
    }
    IEnumerator FadeIn()
    {
        for (float alpha = 0; alpha < 1; alpha += speed * Time.deltaTime)
        {
            Color currentColor = rend.color;
            currentColor.a = alpha;
            rend.color = currentColor;

            yield return new WaitForSeconds(coroutineTime);
        }
        StartCoroutine(FadeOut());
    }
}

