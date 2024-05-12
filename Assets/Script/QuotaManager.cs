using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuotaManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI day;
    [SerializeField] private TextMeshProUGUI quotaText;
    [SerializeField] private GameObject payPanel;
    [SerializeField] private Button home;
    [SerializeField] private Button shop;
    [SerializeField] private Button pay;


    [SerializeField] private int[] quota;
    [SerializeField] private int[] deadline;

    private GameManager gm
    { get { return GameManager.Instance; } }

    private void Start()
    {
        gm.SaveGame();
        gm.day++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (gm.deadIndex < deadline.Length)
        {
            day.SetText("Day " + gm.day + "/" + deadline[gm.deadIndex]);
            quotaText.SetText("/" + quota[gm.deadIndex]);
            if (gm.day == deadline[gm.deadIndex]) CollectionDay();
        }
        else
        {
            day.SetText("Day " + gm.day);
            quotaText.SetText(" DEBT FREE");
        }
    }

    private void CollectionDay()
    {
        home.interactable = false;
        shop.interactable = false;

        payPanel.SetActive( true );
    }

    public void PayCollectors()
    {
        if (gm.money >= quota[gm.deadIndex])
        {
            gm.money -= quota[gm.deadIndex];
            home.interactable = true;
            shop.interactable = true;
            payPanel.SetActive(false);
            gm.deadIndex++;
            UpdateUI();
        }
        else
        {
            gm.ResetGame();
            SceneManager.LoadScene("LStart");
        }

    }
}
