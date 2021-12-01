using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    protected Transform playerTransform;
	protected bool collidingWithPlayer;
    public ContactFilter2D filter;

    private Vector3 direction = Vector3.zero;

    private float lastDirectionChangeTime;
    private float moveDuration;
    private Collider2D[] hits = new Collider2D[10];

    private Animator anim;
    public float triggerLength  = 100f;
	public float chaseLength = 150f;
	private bool chasing;
    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform; 
        lastDirectionChangeTime = Time.time;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {   if (! transform) return;
    
        if (!playerTransform) NormalMovement();


        if (Vector3.Distance(playerTransform.position, transform.position) < chaseLength){
			if (Vector3.Distance(playerTransform.position, transform.position) < triggerLength) chasing = true;
			
			if (chasing) {
				if (!collidingWithPlayer)
				{
                    anim.SetBool("IsMoving", true);
					UpdateMotor((playerTransform.position - transform.position).normalized);
				}
			} else {
				NormalMovement();
			}
		} else {
			chasing = false;
            NormalMovement();
		}        

        collidingWithPlayer = false;
		boxCollider.OverlapCollider(filter, hits);
		for (int i=0; i<hits.Length; i++)
		{
			if(hits[i] == null) continue;

			if(hits[i].name =="Player"){
				collidingWithPlayer = true;
			}
			
			hits[i]=null; 
		}
        
    }

    private void NormalMovement(){
        if (Time.time - lastDirectionChangeTime > moveDuration) {
            direction = Motions.GetARandomDirection();
            if (Random.Range(-1,3) < 0) {
                direction = Vector3.zero;
                anim.SetBool("IsMoving", false);
            } else {
                anim.SetBool("IsMoving", true);
            }
            moveDuration = Random.Range(2f, 10f);
            lastDirectionChangeTime = Time.time;
        }
        UpdateMotor(direction);

    }


}
