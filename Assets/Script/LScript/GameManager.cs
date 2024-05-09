using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    //0 1 2 hookspeed, 3 4 5 boatspeed, 6 cave, 7 swamp, 8 lava, 9 dex, 10 bigfish, 11 moneyUp
    public bool[] upgrades = { false, false, false, false, false, false, false, false, false, false, false, false };

    public int money = 0;

    public int day = 1;
    public int deadline = 3;

    public float hSpeed = 2;
    public float bSpeed = 3;

    public int startTime = 6;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}








