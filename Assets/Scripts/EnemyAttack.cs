using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [Header("Animator")] //ANIMATOR DE ENEMIGO
    private Animator _animator;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
           
        }
    }
}
