using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private GameObject player;
    private float cameraYPos; // No se usa pero puede que lo use para la siguiente entrega.
    void Start()
    {
        player = FindObjectOfType<platformMovement>().gameObject; // Obtenemos el jugador.
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, transform.position.z); // La c�mara ahora seguir� �l jugador en el eje x, pero el eje y ser� 0.
    }
}
