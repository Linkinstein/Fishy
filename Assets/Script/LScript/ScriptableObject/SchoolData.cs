using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SchoolData", menuName = "SchoolData")]
public class SchoolData : ScriptableObject
{
    [SerializeField] public GameObject[] fish;
    [SerializeField] public float[] distances;
}
