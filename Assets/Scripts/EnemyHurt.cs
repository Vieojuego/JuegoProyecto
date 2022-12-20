using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyHurt : MonoBehaviour
{
    
    
    public static EnemyHurt Instance;
    public int healt;
    public GameObject[] myObjects;
    public float[] Drops;
    private Dictionary<GameObject,float> _collectibles;

    private float _cooldownDmg;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _collectibles = new Dictionary<GameObject, float>();
        
        for (int i = 0; i < myObjects.Length; i++)
        {
            _collectibles.Add(myObjects[i],Drops[i]);
        }
        _cooldownDmg = 0.3f;
    }

    private void Update()
    {
        _cooldownDmg -= Time.deltaTime;
    }

    public void hurtEnemy(int dmg)
    {
        if (_cooldownDmg <= 0)
        {
            _cooldownDmg = 0.3f;
            healt -= dmg;
            if (healt <= 0)
            {
                float dropSelect = Random.Range(0,100f);


                foreach(var item in _collectibles)
                {
                    if (dropSelect <= item.Value)
                    {
                        Instantiate(item.Key, gameObject.transform.position,gameObject.transform.rotation);
                    }
                }
                
                
                Destroy(gameObject);
                
            }
        }
    }
}
