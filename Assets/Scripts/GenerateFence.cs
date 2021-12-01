using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFence : MonoBehaviour
{
    public GameObject leftFence;
    public GameObject horizontalFence;
    public GameObject rightFence;
    // Start is called before the first frame update
    void Awake()
    {
        //generate upper fence
        Vector3 startingPoint = new Vector3(-30, 30, 0);
        for( int i =0; i< 20; i++){
            Instantiate(horizontalFence, startingPoint, Quaternion.identity);
            startingPoint.x += 3f;
        }

        for( int i =0; i< 20; i++){
            Instantiate(rightFence, startingPoint, Quaternion.identity);
            startingPoint.y -= 3f;
        }

        for( int i =0; i< 20; i++){
            Instantiate(horizontalFence, startingPoint, Quaternion.identity);
            startingPoint.x -= 3f;
        }
        
        for( int i =0; i< 20; i++){
            Instantiate(leftFence, startingPoint, Quaternion.identity);
            startingPoint.y += 3f;
        }


    }

    // Update is called once per frame
    
}
