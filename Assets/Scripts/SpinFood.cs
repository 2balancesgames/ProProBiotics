using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFood : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    private int speed = 1;
    private int spinSpeed;
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        spinSpeed = Random.Range(-100, 100);
    }
    void Update()
    {   
        transform.Rotate(0,0,spinSpeed*Time.deltaTime);
        transform.Translate(direction*Time.deltaTime*speed, Space.World);
    }
}
