using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtarget : MonoBehaviour
{
    
    
        public float radius = 5f;   // Radius of the circle
    public float speed = 2f;    // Speed of the rotation

    private float angle = 0f;   // Current angle

    void Update()
    {

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;


        transform.position = new Vector3(x, y, 0f);


        angle += speed * Time.deltaTime;


        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
