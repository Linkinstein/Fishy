using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LFish : MonoBehaviour
{

    public GameObject spawner;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int _x = 1;

    [SerializeField] public string fishName;
    [SerializeField] public int fishValue;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] public bool tail = true;

    public bool caught = false;
    public Transform hook = null;

    public bool ended
    { 
        get { return TripManager.Instance.ended; }
    }

    public int x
    {
        get { return _x; }
        set
        {
            if (value < 0) transform.localScale = new Vector2(-1, transform.localScale.y);
            _x = value;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!caught) rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        else rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (caught && hook != null)
        { 
            transform.position = hook.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DespawnerL") && x == -1)
        {
            if (tail && !ended) spawner.GetComponent<Spawner>().SpawnFish();
            Destroy(this.gameObject);
        }


        if (collision.gameObject.CompareTag("DespawnerR") && x == 1)
        {
            if (tail && !ended) spawner.GetComponent<Spawner>().SpawnFish();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Boat"))
        {
            if (!ended)
            {
                if (tail) spawner.GetComponent<Spawner>().SpawnFish();
                TripManager.Instance.AddFish(fishName, fishValue, sr.sprite);
            }
            Destroy(this.gameObject);
        }
    }
}
