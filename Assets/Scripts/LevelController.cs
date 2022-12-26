using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public int gemsCollected;

    private void Awake()
    {
        Instance = this;
    }
    
}
