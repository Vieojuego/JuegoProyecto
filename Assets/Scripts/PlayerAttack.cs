using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static  PlayerAttack Instance;
    private bool _isAttack;
    public int dmg;


    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        // Comprobar si la animación de atacar está activada
        Animator animator = PlayerMovement.Instance.animation;
        if( animator.GetCurrentAnimatorStateInfo(0).IsName("Warrior_Attack") )
        {
            _isAttack = true;
        }
        else
        {
            _isAttack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Si estamos atacando y estamos colisionando con un enemigo
        if (other.gameObject.CompareTag("Enemy") && _isAttack)
        {
            other.GetComponent<EnemyHurt>().hurtEnemy(dmg);
            
            
        }
    }
    
}
