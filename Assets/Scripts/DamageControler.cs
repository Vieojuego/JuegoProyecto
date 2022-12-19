using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControler : MonoBehaviour
{
    private bool _isAttack;

    public static DamageControler Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Animator animator = EnemyControler.Instance.animator;

        // Si chocamos con la zona de ataque de un Enemigo
        if (other.gameObject.CompareTag($"EnemyHurt"))
        {
            if( animator.GetCurrentAnimatorStateInfo(0).IsName("Momia_Attack")) // Comprobamos si está haciendo la animación de atacar
            {
                _isAttack = true;
            }
            else
            {
                _isAttack = false;
            }
        

            if (_isAttack)
            {
                int dmg = EnemyControler.Instance.damage;
                HealthController.Instance.Hurt(dmg);
            }
        }
    }
}
