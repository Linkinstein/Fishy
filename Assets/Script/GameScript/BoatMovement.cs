using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public bool pause = false;

    void Update()
    {
        if (!pause)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;


            transform.position += movement;

            transform.position = new Vector3(transform.position.x, 3.47f, transform.position.z);
        }
    }
}

