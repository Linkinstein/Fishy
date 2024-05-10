using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance { get; private set; }
    [SerializeField] private GameObject Fish;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject Exit;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] instruction;


    private int i = 0;

    public int index
    {
        set 
        { 
            i = value;
            StartCoroutine(Next());
        }
    }


    private void Awake()
    {
        if (Instance == null) Instance = this; 
        else Destroy(gameObject); 
    }

    private IEnumerator Next()
    {
        text.SetText(instruction[i]);
        yield return new WaitForSeconds(1);
        Step();
    }

    private void Step()
    {
        switch (i) 
        { 
            case 1: 
                Fish.SetActive(true); 
                break;
            case 2:
                Spawner.GetComponent<TutorialSpawner>().SpawnFish();
                break;
            case 3:
                Exit.SetActive(true);
                break;
            default:
                break;
        }
    }
}
