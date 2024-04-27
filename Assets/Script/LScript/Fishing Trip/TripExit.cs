using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TripExit : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    private Image sr;

    public bool ended
    {
        get { return TripManager.Instance.ended; }
    }
    public bool exitable
    {
        get { return TripManager.Instance.exitable; }
    }

    private void Start()
    {
        sr = GetComponent<Image>();
    }

    private void Update()
    {
        if (exitable) sr.sprite = sprite;
    }

    public void exitClick()
    {
        if (!ended) StartCoroutine(TripManager.Instance.CheckGameOver());
        else if (exitable) SceneManager.LoadScene("Home");
    }
}