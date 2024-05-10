using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SchoolData[] mornSchool;
    [SerializeField] private SchoolData[] noonSchool;
    [SerializeField] private SchoolData[] nightSchool;
    [SerializeField] private int x = 1;

    private TripManager tm
    { get { return TripManager.Instance; } }

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
        SchoolData[] school = mornSchool;

        if (tm.hour < 12) school = mornSchool; 
        if (tm.hour >= 12 && tm.hour < 18) school = noonSchool;
        if (tm.hour >= 18) school = nightSchool;

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
        SchoolData[] school = mornSchool;

        if (tm.hour < 12) school = mornSchool;
        if (tm.hour >= 12 && tm.hour < 18) school = noonSchool;
        if (tm.hour >= 18) school = nightSchool;

        return Random.Range(0, school.Length);
    }
}
