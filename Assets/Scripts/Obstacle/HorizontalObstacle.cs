using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 2, 0);
    }
}
