using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlay : MonoBehaviour
{
    // private Animation anim;    

    // void Start()
    // {
    //     anim = GetComponent<Animation>();
    // }
	protected virtual void LateUpdate()
    {
        // anim.Play();
        Destroy(gameObject,0.2f);
        
    }

}