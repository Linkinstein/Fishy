using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovementLeft : MonoBehaviour
{
    public float speed = 2.0f;
    private bool movingLeft = true;

    private float boundaryRight = 10.0f;
    private float boundaryLeft = -10.0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * (movingLeft ? 1 : -1));

        if (movingLeft && transform.position.x <= boundaryLeft)
        {
            FlipDirection();
        }
        else if (!movingLeft && transform.position.x >= boundaryRight)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        movingLeft = !movingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}





