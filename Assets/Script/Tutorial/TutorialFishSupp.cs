using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFishSupp : MonoBehaviour
{
    [SerializeField] private int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boat"))
        {
            Tutorial.Instance.index = i;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("DespawnerR")) Destroy(this.gameObject);
    }
}
