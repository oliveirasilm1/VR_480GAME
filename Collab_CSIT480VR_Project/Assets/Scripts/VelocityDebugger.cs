using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class VelocityDebugger : MonoBehaviour
{

    [SerializeField]
    private float maxVelocity = 20f; // this would be red (indication)

    private void Update()
    {
        GetComponent<Renderer>().material.color = ColorForVelocity();
    }
    
    private Color ColorForVelocity()
    {
        float velocity = GetComponent<Rigidbody>().velocity.magnitude;
        return Color.Lerp(Color.green, Color.red, velocity / maxVelocity);
    }

    // Update is called once per frame

}
