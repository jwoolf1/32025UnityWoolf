using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class coindestroing : MonoBehaviour
{

    private void Start()
    {

    }
    private void Update()
    {
        if (transform.position.x < -18)
        {
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
     
        
    }
}

