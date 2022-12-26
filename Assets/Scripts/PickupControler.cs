using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControler : MonoBehaviour
{
    public bool isGold;
    private bool _isCollected;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isGold && !_isCollected)
            {
                LevelController.Instance.gemsCollected++;
                _isCollected = true;
                Destroy(gameObject);
             }
             
        
        }
    }
}
