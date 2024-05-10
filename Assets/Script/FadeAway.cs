using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField] private float i;

    private void OnEnable()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    { 
        yield return new WaitForSeconds(i);
        this.gameObject.SetActive(false);
    }
}
