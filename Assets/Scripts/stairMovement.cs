using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairMovement : MonoBehaviour
{
    public float speed;
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(0, y) * speed * Time.deltaTime);
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
