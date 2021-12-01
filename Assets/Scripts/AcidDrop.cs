using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    private float x, y;
    private float speed = 4;
    public void Start()
    {
        Destroy(gameObject, 3);
    }
    public void Update()
    {
        Vector3 delta = new Vector3(this.x, this.y, 0);
        delta = delta / delta.magnitude;
        transform.Translate(delta * speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetSpeed(float speed){
        this.speed = speed;
    }



}