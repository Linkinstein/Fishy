using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private AudioSource aS;

    public Transform boat;
    public Vector3 startPosition;
    private bool caughtFish;
    [SerializeField] private Transform bottom;
    public float speed = 2f;

    public bool ended
    {
        get { return TripManager.Instance.ended; }
    }

    public GameManager gm
    {
        get { return GameManager.Instance; }
    }



    private void Start()
    {
        speed = gm.hSpeed;
        if (gm.upgrades[0]) speed += 1;
        if (gm.upgrades[1]) speed += 1;
        if (gm.upgrades[2]) speed += 1;
        startPosition = transform.localPosition;
        aS = GetComponent<AudioSource>();
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
            aS.Play();
        }

        if (other.CompareTag("BigFish") && !caughtFish && gm.upgrades[10])
        {
            caughtFish = true;
            other.GetComponent<LFish>().hook = transform;
            other.GetComponent<LFish>().caught = true;
            aS.Play();
        }
    }

}
