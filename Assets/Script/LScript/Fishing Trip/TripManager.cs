using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TripManager : MonoBehaviour
{
    [SerializeField] private bool tutorial = false;

    public static TripManager Instance { get; private set; }

    public List<FishCaughtData> fishList = new List<FishCaughtData>();

    [SerializeField] private SpriteRenderer backdrop;
    [SerializeField] private Color nightColor;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject mainPrefab;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] timeCompass;


    public int hour = 6;
    private int minute = 00;
    private int totalEarned;
    private int totalFishes;

    public bool ended = false;
    public bool exitable = false;

    private GameManager gm
    { get { return GameManager.Instance; } }

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
        if (!tutorial)
        {
            hour = gm.startTime;
            StartCoroutine(CountdownTimer());
        }
    }

    private void Update()
    {
        if (!tutorial) backdropDarker();
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
        int deno = 0;
        string ampm = "AM";
        timeText.text = (hour - deno).ToString("00") + ":" + minute.ToString("00") + ampm;
        while (hour != 24 && !ended)
        {
            if (hour == 12) ampm = "PM";
            if (hour == 13) deno = 12;
            yield return new WaitForSeconds(1);
            minute += 15;
            if (minute == 60)
            {
                minute = 0;
                hour++;
            }
            turnTimeCompass();
            timeText.text = (hour - deno).ToString("00") + ":" + minute.ToString("00") + ampm;
        }
        if (!ended) StartCoroutine(CheckGameOver());
    }

    private void backdropDarker()
    {
        int x = (hour * 100) + minute;
        if (hour <= 8)
        {
            float t = ((x - 600f) / 200f);
            backdrop.color = Color.Lerp(nightColor, Color.white, t);
        }

        if (hour >= 19)
        {
            float t = Mathf.Clamp01((x - 1800f) / 600f);
            backdrop.color = Color.Lerp(Color.white, nightColor, t);
        }
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

    public IEnumerator CheckGameOver()
    {
        ended = true;
        endScreen.SetActive(true);
        foreach (var fish in fishList)
        {
            yield return new WaitForSeconds(0.25f);
            GameObject npi = Instantiate(mainPrefab, panels[0].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[0].transform, false);
            npi.GetComponent<EndScreenMainPanel>().panelSetup(fish.fishName, fish.fishIMG);

            yield return new WaitForSeconds(0.25f);
            npi = Instantiate(textPrefab, panels[1].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[1].transform, false);
            npi.GetComponent<TextMeshProUGUI>().text = "x" + fish.quantity;
            totalFishes += fish.quantity;
            panels[3].GetComponent<TextMeshProUGUI>().text = "x" + totalFishes;

            yield return new WaitForSeconds(0.25f);
            npi = Instantiate(textPrefab, panels[2].transform.position, Quaternion.identity);
            npi.transform.SetParent(panels[2].transform, false);
            npi.GetComponent<TextMeshProUGUI>().text = "$" + fish.totalValue;
            totalEarned += fish.totalValue;
            panels[4].GetComponent<TextMeshProUGUI>().text = "$" + totalEarned;
        }
        yield return new WaitForSeconds(0.25f);
        if (gm.upgrades[11])totalEarned = (int)(totalEarned*1.5);
        panels[4].GetComponent<TextMeshProUGUI>().text = "$" + totalEarned;
        GameManager.Instance.money += totalEarned;
        exitable = true;
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
