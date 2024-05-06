using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Transform boat;
    public Vector3 startPosition;
    private bool caughtFish;
    [SerializeField] private Transform bottom;

    public bool ended
    {
        get { return TripManager.Instance.ended; }
    }

    public float speed
    {
        get { return GameManager.Instance.speed; }
    }



    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!ended)
        {
            if (Input.GetKey(KeyCode.Space) && !(transform.position.y <= bottom.position.y) && !caughtFish)
            {
                if (boat.GetComponent<LBoatMovement>() != null) boat.GetComponent<LBoatMovement>().pause = true;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (transform.localPosition.y <= startPosition.y && !caughtFish)
            {
                returning();
            }

            if (caughtFish)
            {
                returning();
            }
        }
    }

    private void returning()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.localPosition.y > startPosition.y)
        {
            transform.localPosition = startPosition;
            if (boat.GetComponent<LBoatMovement>() != null) boat.GetComponent<LBoatMovement>().pause = false;
            caughtFish = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish") && !caughtFish)
        {
            caughtFish = true;
            other.GetComponent<LFish>().hook = transform;
            other.GetComponent<LFish>().caught = true;
        }
    }

}
