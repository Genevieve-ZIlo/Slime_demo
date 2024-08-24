using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWobble : MonoBehaviour
{

    public GameObject sphere;
    private Wobble wobbleScript;

    void Start()
    {

        if (sphere != null)
        {
            wobbleScript = sphere.GetComponent<Wobble>();
        }
    }

    public void ToggleWobbleScript()
    {
        if (wobbleScript != null)
        {
            wobbleScript.enabled = !wobbleScript.enabled;
        }
        
    }
}
