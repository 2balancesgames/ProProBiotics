using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mover: MonoBehaviour { // if abstract then cannot drag&drop
    public BoxCollider2D boxCollider;
	protected RaycastHit2D hit;
	public float speed = 3.0f;

	protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
	}	


	protected virtual void UpdateMotor(Vector3 input)
	{
		//Reset MoveDelta
		Vector3 delta = new Vector3(input.x * speed * Time.deltaTime, input.y * speed * Time.deltaTime, 0);
		// swap sprite direction , wether you're going right or left
		if (delta.x > 0)
			transform.localScale = Vector3.one;
		else if (delta.x < 0)
		    transform.localScale = new Vector3(-1 ,1,0);

		// // add push vector, if any
		// moveDelta += pushDirection;
		// pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed); // 慢慢减少push 不然会一直push没边

	    hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, delta.y), Mathf.Abs(delta.y), LayerMask.GetMask("Character", "Building") );	 

        if (hit.collider == null) {
	    	transform.Translate(0, delta.y, 0);
        } 
	    hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(delta.x, 0), Mathf.Abs(delta.x), LayerMask.GetMask("Character", "Building") );
        if (hit.collider == null) {
	    	transform.Translate(delta.x, 0, 0);
	    } 
	}
    // void OnDrawGizmos()
    // {
    //     float x = Input.GetAxisRaw("Horizontal");
	// 	float y = Input.GetAxisRaw("Vertical");
    //     Vector3 delta = new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);

    //     Gizmos.DrawWireCube(transform.position + delta, boxCollider.size);
    // }
}