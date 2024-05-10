using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private int i;
    [SerializeField] private UpgradeData upgrade;
    [SerializeField] private Button buyButt;
    [SerializeField] private TextMeshProUGUI iName;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private GameObject youBroke;
    [SerializeField] private Image img;

    GameManager gm
    { get { return GameManager.Instance; } }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => itemView());
    }
    public void itemView()
    {
        youBroke.SetActive(false);
        iName.text = upgrade.iName;
        cost.text = "$" + upgrade.cost;
        desc.text = upgrade.desc;
        img.sprite = upgrade.icon;
        buyButt.interactable = true;
        buyButt.onClick.RemoveAllListeners();
        if (gm.upgrades[i]) buyButt.interactable = false;
        else buyButt.onClick.AddListener(() => buyClick());
    }

    public void buyClick()
    {
        if (gm.money >= upgrade.cost)
        {
            gm.money -= upgrade.cost;
            gm.upgrades[i] = true;

            buyButt.onClick.RemoveAllListeners();
            buyButt.interactable = false;
        }
        else youBroke.SetActive(true);
    }
}
