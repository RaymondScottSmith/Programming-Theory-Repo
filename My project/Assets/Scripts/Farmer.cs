using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Runner
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter Called");
        if (other.CompareTag("Obstacle"))
        {
            Jump();
        }
    }
}
