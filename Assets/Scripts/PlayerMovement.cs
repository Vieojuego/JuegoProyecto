using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    [Header("Attributes")]
    public float speed;
    public float jumpForce;

    private float _horizontal;
    private float _direction;
    private float _rotateX;
    private float _rotateY;
    private bool _grounded;
    
    [Header("Physics")]
    private Rigidbody2D _rgb;
    
    [Header("Animation")] 
    public new Animator animation;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Capturar Animator, y el rigid
        _rgb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        
        // Capturar el localScale de x-y
        var localScale = transform.localScale;
        _rotateX = localScale.x;
        _rotateY = localScale.y;
        
    }

    
    void Update()
    {
        
        // Controlar si vamos derecha o izquierda
        _horizontal = Input.GetAxisRaw("Horizontal");
        animation.SetFloat("Horizontal", Mathf.Abs(_horizontal));
        if (_horizontal < 0.0f) transform.localScale = new Vector3(-_rotateX,_rotateY,1);
        else if (_horizontal > 0.0f) transform.localScale = new Vector3(_rotateX, _rotateY, 1);

        
        // Controlar El space, para Saltar
        if(Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
        
        // Atacar si hacemos Click y no estamos saltando
        
        if (Input.GetMouseButtonDown(0) && _grounded==true)
        {
            AttackPlayer();
        }

    }

    private void FixedUpdate()
    {
        _rgb.velocity = new Vector2(_horizontal  * speed, _rgb.velocity.y);
        
    }

    private void Jump()
    {
        // Aplicamos el salto, y el booleano que detecta que no estamos ya en el suelo pasa a false;
        _rgb.AddForce(Vector2.up * jumpForce);
        _grounded = false;
        animation.SetBool("Jump",_grounded); // Activamos la animación de saltar
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag($"Ground")) // Comprobar si estamos en el suelo
        {
            _grounded = true;
            animation.SetBool("Jump",_grounded); // Desactivamos la animación de saltar
        }

        

    }

    private void AttackPlayer()
    {
        animation.SetTrigger("Attack");
        
    }

    
}
