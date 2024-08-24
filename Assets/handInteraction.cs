using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour
{
    public float interactionDisplacement = 0.5f; // Amount of displacement when hands interact

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a hand
        if (collision.gameObject.CompareTag("Hand"))
        {
            // Apply increased displacement effect
            GetComponent<Renderer>().material.SetFloat("_Displacement", interactionDisplacement);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Reset displacement when hand interaction ends
        if (collision.gameObject.CompareTag("Hand"))
        {
            GetComponent<Renderer>().material.SetFloat("_Displacement", 0.2f); // Reset to default value
        }
    }
}

