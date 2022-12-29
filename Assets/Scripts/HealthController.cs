using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController Instance;
    public int health;
    
    public float invincibleLenght;
    private float _invincibleCounter;

    private SpriteRenderer _sr;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (_invincibleCounter > 0)
        {
            _invincibleCounter -= Time.deltaTime;
            
            if (_invincibleCounter <= 0)
            {
                _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1f);
            }
        }
        
    }

    public void Hurt(int dmg)
    {
        if (_invincibleCounter <= 0)
        {
            health -= dmg;
            UiController.Instance.UpdateHeal();
            PlayerMovement.Instance.NockBack();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _invincibleCounter = invincibleLenght;
                _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, .5f);
            }
            
        }
        
    }
}
