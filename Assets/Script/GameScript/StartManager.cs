using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Button loadButt;
    private GameManager gm
    { get { return GameManager.Instance; } }

    private void Start()
    {
        if (PlayerPrefs.GetInt("started", 0) == 0) loadButt.interactable = false;
    }

    public void NewGame()
    {
        gm.ResetGame();
        PlayerPrefs.SetInt("started", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadGame()
    {
        gm.LoadGame();
        SceneManager.LoadScene("Home");
    }
}

