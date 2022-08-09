using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Runner
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && isOnGround && !GameManager.Instance.isGameOver)
        {
            Jump();
        }
    }
    
    
}
