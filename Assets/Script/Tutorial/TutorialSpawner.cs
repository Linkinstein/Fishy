using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPre;
    [SerializeField] private int x;

    public void SpawnFish()
    {
        GameObject fishy = Instantiate(fishPre, transform.position, Quaternion.identity);
        LFish fishS = fishy.GetComponent<LFish>();
        fishS.x = x;
        fishS.spawner = this.gameObject;
        fishS.tail = true;
    }

}
