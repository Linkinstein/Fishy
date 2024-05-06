using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtons : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] tabs;

    public void GoToMap()
    {
        anim.SetTrigger("2map");
        StartCoroutine(transition(0));
    }
    public void GoToHome()
    {
        anim.SetTrigger("2home");
        StartCoroutine(transition(1));
    }

    public void GoToStore()
    {
        anim.SetTrigger("2store");
        StartCoroutine(transition(2));
    }

    public void GoToSea()
    {
        SceneManager.LoadScene("SeaLevel");
    }

    public void GoToLava()
    {
        SceneManager.LoadScene("LavaLevel");
    }
    public void GoToCave()
    {
        SceneManager.LoadScene("CaveLevel");
    }
    public void GoToSwamp()
    {
        SceneManager.LoadScene("SwampLevel");
    }

    private IEnumerator transition(int i)
    { 
        foreach (var tab in tabs) 
        { 
            tab.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        tabs[i].SetActive(true);
    }
}
