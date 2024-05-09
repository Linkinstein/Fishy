using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //0 sea,1 cave, 2 swamp, 3 lava
    [SerializeField] private GameObject[] panels;

    public void openSea()
    {
        foreach (GameObject go in panels) 
        { 
            go.SetActive(false);
        }
        panels[0].SetActive(true);
    }

    public void openCave()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        panels[1].SetActive(true);
    }

    public void openSwamp()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        panels[2].SetActive(true);
    }

    public void openLava()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        panels[3].SetActive(true);
    }
}
