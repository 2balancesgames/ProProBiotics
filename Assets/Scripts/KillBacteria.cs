using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBacteria : Collidable
{
    

    protected override void OnCollide(Collider2D coll){
        if (coll.tag =="Bacteria") {
            Debug.Log(coll.name);
            if (coll.name != "Player"){
                coll.gameObject.GetComponent<Mortal>().Death();
                StartCoroutine(Reproduce(coll.gameObject.transform.position, 1f));
            } else {
                GameManager.instance.TakeThreeImpact(3,3,3);
                GameManager.instance.ShowText("Gut Conditions +3!", 30, Color.red, transform.position + new Vector3(0, 0.5f, 0), new Vector3(0, 30, 0), 3f);
            }
            
        }
    }

    IEnumerator Reproduce( Vector3 location,  float delay)
    {
        // you can delay the animation
        yield return new WaitForSeconds(delay);
        Instantiate(gameObject, location, Quaternion.identity);

    }
}
