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
    [SerializeField] private Button[] travel;
    [SerializeField] private Button pay;


    [SerializeField] private int[] quota;
    [SerializeField] private int[] deadline;

    private GameManager gm
    { get { return GameManager.Instance; } }

    private void Start()
    {
        gm.SaveGame();
        gm.day++;
        day.SetText( "Day " + gm.day + "/" + deadline[gm.deadIndex] );
        quotaText.SetText( "/" + quota[gm.deadIndex] );

        if (!(gm.deadIndex >= deadline.Length ) && gm.day == deadline[gm.deadIndex]) CollectionDay();
    }

    private void CollectionDay()
    {
        foreach (Button butt in travel)
        { 
            butt.interactable = false;
        }

        payPanel.SetActive( true );
    }

    public void PayCollectors()
    {
        if (gm.money >= quota[gm.deadIndex])
        {
            gm.money -= quota[gm.deadIndex];
            foreach (Button butt in travel)
            {
                butt.interactable = true;
            }
            payPanel.SetActive(false);
            gm.deadIndex++;
        }
        else
        {
            gm.ResetGame();
            SceneManager.LoadScene("LStart");
        }

    }
}
