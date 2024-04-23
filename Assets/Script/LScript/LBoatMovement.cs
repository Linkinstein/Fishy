using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBoatMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to change player speed
    public bool pause = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!pause)
        {
            // Get input for horizontal movement
            float moveInput = Input.GetAxis("Horizontal");

            // Calculate movement direction
            Vector2 moveDirection = new Vector2(moveInput, 0f);

            // Move the player
            rb.velocity = moveDirection * speed;
        }
        else
        {
            // Stop the player if pause is true
            rb.velocity = Vector2.zero;
        }
    }
}
