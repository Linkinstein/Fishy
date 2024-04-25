using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    public GameObject rope;
    public Transform boat;
    public float speed = 2.0f;
    private bool isDescending = false;
    private bool hasFish = false;
    private GameObject caughtFish = null;
    private int fishPoints = 0;
    private Vector3 startPosition;
    private bool returning = false;

    private void Start()
    {
        //startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDescending && !hasFish)
        {
            isDescending = true;
            if (boat.GetComponent<BoatMovement>() != null) boat.GetComponent<BoatMovement>().pause = true;
            if (boat.GetComponent<LBoatMovement>() != null) boat.GetComponent<LBoatMovement>().pause = true;
            startPosition = transform.position;
        }

        if (isDescending)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.localPosition.y <= -8.5f)
            {
                StartReturning();
            }
        }
        
        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (hasFish)
            {
                caughtFish.transform.position = transform.position;
            }
            if (transform.position == startPosition)
            {
                if (boat.GetComponent<BoatMovement>() != null) boat.GetComponent<BoatMovement>().pause = false;
                if (boat.GetComponent<LBoatMovement>() != null) boat.GetComponent<LBoatMovement>().pause = false;
                returning = false; 
                if (hasFish)
                {
                    GGameManager.Instance.AddPoints(fishPoints);
                    hasFish = false;
                    caughtFish.SetActive(false);
                    caughtFish = null;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasFish && other.CompareTag("Fish"))
        {
            hasFish = true;
            caughtFish = other.gameObject;
            caughtFish.transform.parent = transform;
            fishPoints = caughtFish.GetComponent<Fish>().pointValue;
            StartReturning();
        }
    }

    private void StartReturning()
    {
        isDescending = false;
        returning = true;
    }
}









