using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public Transform target;
    public static EnemyControler Instance;


    [Header("Atributes")] public int damage;
    public float velocity;

    public Transform maxRight, maxLeft; // Rango maximo de recorrido
    private bool _moveRight;
    private float _turnX, _turnY;
    public float distancePlayer;
    public bool followPlayer;

    [Header("Animacion")] public Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        maxLeft.parent = null;
        maxRight.parent = null;
        // Rango de giro
        _turnX = transform.localScale.x;
        _turnY = transform.localScale.y;
    }

    // Update is called once per frame
    private void Update()
    {
        distancePlayer = target.transform.position.x - transform.position.x;
        followPlayer = distancePlayer is >= -5 and <= 5;
        if (!followPlayer)
        {
            Movimiento();
        }
        else
        {
            if (distancePlayer > 0)
            {
                transform.localScale = new Vector3(-_turnX, _turnY, 1f);
            }
            else
            {
                transform.localScale = new Vector3(_turnX, _turnY, 1f);
            }

            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(target.position.x, transform.position.y), velocity * Time.deltaTime);
        }
    }

    public void Movimiento()
    {
        if (_moveRight)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(maxRight.position.x, transform.position.y), velocity * Time.deltaTime);
            transform.localScale = new Vector3(-_turnX, _turnY, 1);

            if (transform.position.x >= maxRight.position.x)
            {
                _moveRight = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(maxLeft.position.x, transform.position.y), velocity * Time.deltaTime);
            transform.localScale = new Vector3(_turnX, _turnY, 1);

            if (transform.position.x <= maxLeft.position.x)
            {
                _moveRight = true;
            }
        }
    }
}