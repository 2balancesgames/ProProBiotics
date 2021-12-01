using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erode : Enemy
{
    // Start is called before the first frame update
    void FixedUpdate(){
        base.FixedUpdate();
        if (collidingWithPlayer){
            GameManager.instance.TakeThreeImpact(-5,-5,-5);
            GameManager.instance.ShowText("Gut Conditions -5!", 30, Color.red, transform.position + new Vector3(0, 0.5f, 0), new Vector3(0, 30, 0), 3f);
        }
    }
}
