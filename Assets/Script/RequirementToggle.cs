using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementToggle : MonoBehaviour
{
    [SerializeField] private bool cave;
    [SerializeField] private bool swamp;
    [SerializeField] private bool lava;

    private GameManager gm
    { get{ return GameManager.Instance; } }

    private void OnEnable()
    {
        if (cave) 
        {
            if (gm.upgrades[6]) this.gameObject.SetActive(false);
        }

        if (swamp)
        {
            if (gm.upgrades[7]) this.gameObject.SetActive(false);
        }

        if (lava)
        {
            if (gm.upgrades[8]) this.gameObject.SetActive(false);
        }   
    }
}
