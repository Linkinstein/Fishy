using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TripManager : MonoBehaviour
{
    public static TripManager Instance { get; private set; }

    public int currentLevel = 1;
    public int pointsToAdvanceLevel = 10;
    public int currentPoints = 0;
    public float timeLimit = 60;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timerText;

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
        UpdatePointsUI();
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + currentPoints + "/" + pointsToAdvanceLevel;
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (timeLimit > 0)
        {
            UpdateTimerUI();
            yield return new WaitForSeconds(1);
            timeLimit -= 1;
        }
        CheckGameOver();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timeLimit) + "s";
        }
    }

    private void CheckGameOver()
    {
        if (currentPoints < pointsToAdvanceLevel)
        {
            LoadGameOverScene();
        }
        else
        {
            LoadCongratulatoryScene();
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void LoadCongratulatoryScene()
    {
        SceneManager.LoadScene("CongratulatoryScene");
    }
}
