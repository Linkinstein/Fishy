using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ropeStretch : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform hook;

    private Vector3 startPoint;
    private Vector3 startScale;

    private void Start()
    {
        startPoint = hook.transform.localPosition;
        startScale = transform.localScale;
    }

    private void Update()
    { 

        float lerpFactor = Mathf.InverseLerp(startPoint.y, -8.5f, hook.transform.localPosition.y);
        float scaleFactor = Mathf.Lerp(0, 5.1f, lerpFactor);

        transform.localScale = new Vector3(startScale.x, startScale.y + scaleFactor, startScale.z);
    }
}
