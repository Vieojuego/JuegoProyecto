using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{

    public Transform target;

    public Transform baground, middleBackground, othermiddleBackground;

    private float _lastPos;
    private float _lastPosy;
    
    void Start()
    {
        _lastPos = transform.position.x; //POSICION ANTERIOR DEL BACKGROUND VEC X
        _lastPosy = transform.position.y; //POSICION ANTERIOR DEL BACKGROUND VEC Y
    }

    
    void Update()
    {
        if (target != null)
        {
            //LA NUEVA POSICION DE LA CAMARA CON EL VECTOR X DEL PLAYER Y EL Y;
            transform.position = new Vector3(target.position.x, target.position.y + 2f, transform.position.z);
            float ammountToMoveX = transform.position.x - _lastPos; //LA POSICION QUE SE TIENE QUE MOVER VECTOR X
            float ammontToMovey = transform.position.y - _lastPosy;  //LA POSICION QUE SE TIENE QUE MOVER VECTOR Y

            baground.position += new Vector3(ammountToMoveX, ammontToMovey, 0f); //BACKGROUND
            middleBackground.position += new Vector3(ammountToMoveX * 0.1f, 0f, 0f); //FONDOMAPA
            othermiddleBackground.position += new Vector3(ammountToMoveX * 0.1f, 0f, 0f); //MONTAÑAS

            _lastPos = transform.position.x; //POSICION ANTERIOR DEL BACKGROUND VEC X
            _lastPosy = transform.position.y; //POSICION ANTERIOR DEL BACKGROUND VEC Y
        }
    }
}
