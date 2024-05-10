using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBoatMovement : MonoBehaviour
{
    public bool pause = false;
    private Rigidbody2D rb;

    public float speed = 3.0f;

    public GameManager gm
    {
        get { return GameManager.Instance; }
    }

    public bool movable
    {
        get { return GameManager.Instance.upgrades[9]; }
    }


    public bool ended
    {
        get { return TripManager.Instance.ended; }
    }

    void Start()
    {
        speed = gm.bSpeed;
        if (gm.upgrades[3]) speed += 1;
        if (gm.upgrades[4]) speed += 1;
        if (gm.upgrades[5]) speed += 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((!pause && !ended) || (movable && !ended))
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
