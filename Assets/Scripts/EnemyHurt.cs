using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyHurt : MonoBehaviour
{
    
    
    public int healt;
    public GameObject[] myObjects;
    public float[] Drops;
    private Dictionary<GameObject,float> _collectibles;

    private float _cooldownDmg;

    private SpriteRenderer _sr;
   

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _collectibles = new Dictionary<GameObject, float>();
        
        for (int i = 0; i < myObjects.Length; i++) //GENERAR EL ARRAY DE COLECCIONABLES
        {
            _collectibles.Add(myObjects[i],Drops[i]);
        }
        _cooldownDmg = 0.3f;
    }
    private void Update()
    {
        _cooldownDmg -= Time.deltaTime;

        if (_cooldownDmg <= 0) // SI EL ENEMIGO PUEDE RECIBIR DAÑO, NO SERÁ TRANSPARENTE
        {
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1f);
        }
    }
    public void hurtEnemy(int dmg) //HACER DAÑO AL ENEMIGO
    {
        if (_cooldownDmg <= 0)  //COMPROBAR SI SE LE PUEDE HACER DAÑO
        {
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.5f); //EL ENEMIGO, SE MARCA COMO QUE HA RECIBDO DAÑO
            _cooldownDmg = 0.3f;
            healt -= dmg;
            if (healt <= 0) //SI EL ENEMIGO ESTÁ EN 0 o MENOS
            {
                float dropSelect = Random.Range(0,100f); //SE GENERA UN NUMERO ALEATORIO ENTRE 0 Y 100
                foreach(var item in _collectibles)  //RECORREMOS EL DICCIONARIO DE COLECCIONABLES
                {
                    if (dropSelect <= item.Value) 
                    {
                        Instantiate(item.Key, gameObject.transform.position,gameObject.transform.rotation); //SI COINCIDE EL NUMERO GENERADO CON LA PROB, LO DROPEARÁ
                    }
                }
                Destroy(gameObject); //DESTRUIR AL ENEMIGO
            }
        }
       
    }
}
