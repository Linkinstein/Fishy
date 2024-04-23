using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SchoolData[] school;
    [SerializeField] private int x = 1;

    private void Start()
    {
        StartCoroutine(InitialSpawn());
    }

    IEnumerator InitialSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        SpawnFish();
    }

    public void SpawnFish()
    {
        int j = RNG();
        int length = school[j].fish.Length;
        for (int i = 0; i < length; i++)
        {
            Vector3 pos = transform.position;
            pos += new Vector3(-school[j].distances[i] * x, 0f, pos.y + 8);
            setupFish(Instantiate(school[j].fish[i], pos, Quaternion.identity), i + 1 == length);
        }
    }

    private void setupFish(GameObject fishy, bool tail) 
    {
        LFish fishS = fishy.GetComponent<LFish>();
        fishS.x = x;
        fishS.spawner = this.gameObject;
        fishS.tail = tail;
    }

    private int RNG()
    {
        return Random.Range(0, school.Length);
    }
}
