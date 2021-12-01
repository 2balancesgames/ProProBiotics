using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : Collidable
{

    protected override void OnCollide(Collider2D coll){
        if (coll.name.StartsWith("food")) {
            if (gameObject.name == "Player"){
                int food_id =int.Parse(coll.name.Split('_')[1]);
                GameManager.instance.foodAmount[food_id]+=1;
            }
            Destroy(coll.gameObject);
        }
    }

}
