using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovementRight : MonoBehaviour
{
    public float speed = 2.0f;
    private bool movingRight = true;

    private float boundaryRight = 10.0f;
    private float boundaryLeft = -10.0f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        if (movingRight && transform.position.x >= boundaryRight)
        {
            FlipDirection();
        }
        else if (!movingRight && transform.position.x <= boundaryLeft)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        movingRight = !movingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}




