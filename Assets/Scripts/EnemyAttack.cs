using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [Header("Animator")] //ANIMATOR DE ENEMIGO
    private Animator _animator;

 
    // Start is called before the first frame update

  

  

    private void OnTriggerStay2D(Collider2D other)
    {
        _animator = EnemyControler.Instance.animator;
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
           
        }
    }
}
