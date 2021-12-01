using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phage : Enemy
{

    public float detectRange = 20f;

    void FixedUpdate()
    {
        DetectBacteria();
        base.FixedUpdate();
    }

    void DetectBacteria(){
        // Vector2[] directions = new Vector2[] {new Vector2(1,0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1)};
        // foreach (Vector2 direction in directions) {
        //     Debug.Log("Checking "+ direction);
        //     RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, direction, Mathf.Abs(detectRange), LayerMask.GetMask("Character") );	 
        //     if (hit.collider != null && hit.collider.tag == "Bacteria" ) {
        //         playerTransform = hit.collider.transform;
        //         break;
        //     } 
        // }
        
    }

    
}
