using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : MonoBehaviour
{
	//public fields
	public int hitpoint = 10;
	public int maxHitpoint = 10;
	public float pushRecoverySpeed = 0.2f;

	// Immunity
	protected float immuneTime = 1.0f;
	protected float lastImmune ;

	//push
	protected Vector3 pushDirection;
    private Animator anim;
	public GameObject deathPreFab;
	private GenerateFood decompose;

	public int acidImpact;
	public int gasImpact;
	public int energyImpact;
    void Start()
    {
        anim = GetComponent<Animator>();
		decompose = GetComponent<GenerateFood>();
		GameManager.instance.TakeThreeImpact(acidImpact, gasImpact, energyImpact);
    }


	//All fighters can receive damage / die
	// protected virtual void ReceiveDamage(Damage dmg)
	// {
	// 	if (Time.time - lastImmune > immuneTime)
	// 	{
	// 		lastImmune = Time.time;
	// 		hitpoint -= dmg.damageAmount;
	// 		pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

	// 		GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);

	// 		if (hitpoint <= 0)
	// 		{
	// 			hitpoint = 0;
	// 			Death();
	// 		}
	// 	}
	// }
    public void TakeDamage(Damage dmg){
        Debug.Log(gameObject.name + "is taking damage "+ dmg.damageAmount);
        hitpoint -= dmg.damageAmount;
        Debug.Log("Current health : "+ hitpoint);
        if (hitpoint <= 0){
            Death();
        }

    }

	protected virtual void Death()
	{
		Debug.Log( name + " is dead");
		GameManager.instance.TakeThreeImpact(-acidImpact, -gasImpact, -energyImpact);
        Destroy(gameObject);
		if (deathPreFab != null ) {
			Instantiate(deathPreFab, transform.position, Quaternion.identity);	
		}
		if (decompose != null){
			decompose.Generate();
		}
	}
}