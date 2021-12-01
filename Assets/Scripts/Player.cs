using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{  
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0) {
            anim.SetBool("IsMoving", true);
        } else {
            anim.SetBool("IsMoving", false);
        }
    }
    private void FixedUpdate(){
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
        UpdateMotor(new Vector3(x, y, 0));
	}

}
