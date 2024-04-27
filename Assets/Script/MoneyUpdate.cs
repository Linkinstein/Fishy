using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.Instance != null) moneyText.SetText("$"+GameManager.Instance.money);
    }
}
