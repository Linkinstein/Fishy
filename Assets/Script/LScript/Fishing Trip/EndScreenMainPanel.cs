using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenMainPanel : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI nametext;

    public void panelSetup(string fishName, Sprite sprite)
    {
        nametext.SetText(fishName);
        img.sprite = sprite;
    }
}
