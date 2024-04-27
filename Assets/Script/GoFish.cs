using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFish : MonoBehaviour
{
    public void GoToLevel()
    {
        SceneManager.LoadScene("LGame");
    }
}
