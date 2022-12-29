using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackVelocity;
    private float _timeAttack;
    
    [Header("Animator")] //ANIMATOR DE ENEMIGO
    private Animator _animator;

    private void Start()
    {
        _timeAttack = attackVelocity;
    }

    private void Update()
    {
        _timeAttack -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        if (other.gameObject.CompareTag("Player") && _timeAttack<=0)
        {
            _timeAttack = attackVelocity;
            _animator.SetTrigger("Attack");
            Debug.Log("Entrar");
        }
    }
}
