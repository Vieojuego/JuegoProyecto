using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{

    public Transform target;

    public Transform baground, middleBackground, othermiddleBackground;

    private float _lastPos;
    // Start is called before the first frame update
    void Start()
    {
        _lastPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        float ammountToMove = transform.position.x - _lastPos;

        baground.position += new Vector3(ammountToMove,0f,0f);
        middleBackground.position += new Vector3(ammountToMove * 0.5f,0f,0f);
        othermiddleBackground.position += new Vector3(ammountToMove * 0.5f,0f,0f);
        
        _lastPos = transform.position.x;
    }
}
