using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UpgradeData", menuName = "UpgradeData")]
public class UpgradeData : ScriptableObject
{
    [SerializeField] public Sprite icon;
    [SerializeField] public string iName;
    [SerializeField] public int cost;
    [SerializeField] public string desc;
}
