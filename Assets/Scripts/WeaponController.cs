using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int weaponLv;
    private Dictionary<int, int> _levelDamage;


    private void Start()
    {
        _levelDamage = new Dictionary<int, int>();//DICCIONARIO DE LEVEL-DAÑO
        _levelDamage.Add(0,10);
        _levelDamage.Add(1,11);
        _levelDamage.Add(2,12);
        _levelDamage.Add(3,15);
        _levelDamage.Add(4,16);
        _levelDamage.Add(5,17);
        _levelDamage.Add(6,20);
        _levelDamage.Add(7,21);
        _levelDamage.Add(8,22);
        _levelDamage.Add(9,25);

        PlayerAttack.Instance.dmg = _levelDamage[weaponLv];

    }
    
    public void SubirLv()//MEJORAR ARMA
    {
        if (weaponLv < 9)
        {
            weaponLv++;
            PlayerAttack.Instance.dmg = _levelDamage[weaponLv];
        }
    }
}
