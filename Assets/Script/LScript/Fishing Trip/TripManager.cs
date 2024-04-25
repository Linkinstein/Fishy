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

    [SerializeField] private float timeLimit = 60;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject mainPrefab;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject[] panels;

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
        timerText.text = "Time: " + Mathf.Ceil(timeLimit) + "s";
        while (timeLimit > 0)
        {
            yield return new WaitForSeconds(1);
            timeLimit -= 1;
            timerText.text = "Time: " + Mathf.Ceil(timeLimit) + "s";
        }
        StartCoroutine(CheckGameOver());
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
