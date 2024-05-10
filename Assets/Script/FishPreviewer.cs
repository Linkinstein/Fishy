using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishPreviewer : MonoBehaviour
{
    [SerializeField] private GameObject fishGO;
    private LFish fish;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI fName;
    [SerializeField] private TextMeshProUGUI value;

    private void OnEnable()
    {
        fish = fishGO.GetComponent<LFish>();
        img.sprite = fishGO.GetComponent<SpriteRenderer>().sprite;
        fName.SetText(fish.fishName);
        value.SetText("$" + fish.fishValue);
    }
}
