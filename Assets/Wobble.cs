using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{

    public float wobbleAmount = 0.1f;  
    public float wobbleSpeed = 1f;     

    private Vector3 originalPosition;
    private float wobbleOffset;

    
    void Start()
    {
        originalPosition = transform.position;
        wobbleOffset = Random.Range(0f, 10f);
    }

    
    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed + wobbleOffset) * wobbleAmount;
        transform.position = originalPosition + new Vector3(0f, wobble, 0f);
    }
}
