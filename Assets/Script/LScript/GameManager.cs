using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    //0 1 2 hookspeed, 3 4 5 boatspeed, 6 cave, 7 swamp, 8 lava, 9 dex, 10 bigfish, 11 moneyUp
    public bool[] upgrades = { false, false, false, false, false, false, false, false, false, false, false, false };

    public int money = 0;

    public int day = 0;
    public int deadIndex = 0;

    public float hSpeed = 2;
    public float bSpeed = 3;

    public int startTime = 6;
    public bool endGame = false;

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

    private void Start()
    {
        if (deadIndex > 9) endGame = true;
    }

    public void LoadGame()
    {
        day = PlayerPrefs.GetInt("day", 0);
        money = PlayerPrefs.GetInt("money", 0);
        deadIndex = PlayerPrefs.GetInt("deadIndex", 0);
        for (int i = 0; i < upgrades.Length; i++)
        {
            string uName = "upgrade" + i;
            upgrades[i] = (PlayerPrefs.GetInt(uName, 0) != 0);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("deadIndex", deadIndex);
        for (int i = 0; i < upgrades.Length; i++)
        { 
            string uName = "upgrade" + i;
            PlayerPrefs.SetInt(uName, (upgrades[i] ? 1 : 0));
        }
        PlayerPrefs.Save();
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("day", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("deadIndex", 0);
        for (int i = 0; i < upgrades.Length; i++)
        {
            string uName = "upgrade" + i;
            PlayerPrefs.SetInt(uName, 0);
        }
        PlayerPrefs.Save();
        LoadGame();
    }
}








