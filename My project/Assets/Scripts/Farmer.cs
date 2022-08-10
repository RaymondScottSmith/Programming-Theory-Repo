using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Runner
{
    //INHERITANCE
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && isOnGround)
        {
            Jump();
        }
    }
    
    
}
