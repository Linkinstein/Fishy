using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TripManager : MonoBehaviour
{
    public static TripManager Instance { get; private set; }

    public List<FishCaughtData> fishList = new List<FishCaughtData>();

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject mainPrefab;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] timeCompass;


    private int hour = 6;
    private int minute = 00;
    private int totalEarned;
    private int totalFishes;

    public bool ended = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    public void AddFish(string fishName, int fishValue, Sprite fishIMG)
    {
        bool found = false;
        foreach (FishCaughtData obj in fishList)
        {
            if (obj.fishName == fishName)
            {
                obj.quantity++;
                obj.totalValue += fishValue;
                found = true;
                break;
            }
        }

        if (!found)
        {
            FishCaughtData fcd = new FishCaughtData(fishName, fishValue, fishIMG);
            fishList.Add(fcd);
        }
    }

    private IEnumerator CountdownTimer()
    {
        string ampm = "AM";
        timeText.text = hour.ToString("00") + ":" + minute.ToString("00") + ampm;
        while (hour != 22)
        {
            if (hour == 12) ampm = "PM";
            yield return new WaitForSeconds(1);
            minute += 5;
            if (minute == 60)
            {
                minute = 0;
                hour++;
            }
            turnTimeCompass();
            timeText.text = hour.ToString("00") + ":" + minute.ToString("00") + ampm;
        }
        StartCoroutine(CheckGameOver());
    }

    private void turnTimeCompass()
    {
        Color gray50 = new Color(0.25f, 0.25f, 0.25f);
        switch (hour)
        {

            case 6:
                timeCompass[0].GetComponent<Image>().color = Color.white;
                timeCompass[1].GetComponent<Image>().color = gray50;
                timeCompass[2].GetComponent<Image>().color = gray50;
                break;
            case 12:
                timeCompass[0].GetComponent<Image>().color = gray50;
                timeCompass[1].GetComponent<Image>().color = Color.white;
                timeCompass[2].GetComponent<Image>().color = gray50;
                break;
            case 20:
                timeCompass[0].GetComponent<Image>().color = gray50;
                timeCompass[1].GetComponent<Image>().color = gray50;
                timeCompass[2].GetComponent<Image>().color = Color.white;
                break;

        }
    }

    private IEnumerator CheckGameOver()
    {
        ended = true;
        endScreen.SetActive(true);
        foreach (var fish in fishList)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject npi = Instantiate(mainPrefab, panels[0].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[0].transform);
            npi.GetComponent<EndScreenMainPanel>().panelSetup(fish.fishName, fish.fishIMG);

            yield return new WaitForSeconds(0.5f);
            npi = Instantiate(textPrefab, panels[1].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[1].transform);
            npi.GetComponent<TextMeshProUGUI>().text = "x" + fish.quantity;
            totalFishes += fish.quantity;
            panels[3].GetComponent<TextMeshProUGUI>().text = "x" + totalFishes;

            yield return new WaitForSeconds(0.5f);
            npi = Instantiate(textPrefab, panels[2].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[2].transform);
            npi.GetComponent<TextMeshProUGUI>().text = "$" + fish.totalValue;
            totalEarned += fish.totalValue;
            panels[4].GetComponent<TextMeshProUGUI>().text = "$" + totalEarned;
        }
    }
}



public class FishCaughtData
{
    public string fishName;
    public int quantity = 1;
    public int totalValue = 0;
    public Sprite fishIMG;

    public FishCaughtData(string name, int v, Sprite img) 
    { 
        fishName = name;
        totalValue += v;
        fishIMG = img;
    }
}
