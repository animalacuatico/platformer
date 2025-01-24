using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<platformMovement>().gameObject;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
    }
}
