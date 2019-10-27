using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float smoothing = 1;
	public float restTime = 1;
	public float resTimer = 0;
	private int posx = 1;
    private int posy = 1;
	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;
	private Animator ainmator;
	
	
	private Vector2 targetPos = new Vector2(1, 1);
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
		ainmator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		rigidbody.MovePosition(Vector2.Lerp(transform.position, targetPos, smoothing * Time.deltaTime));
		
		resTimer += Time.deltaTime;
		if (resTimer < restTime) return; 

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		if (h > 0)
		{
			v = 0;
		}

		if (h != 0 || v != 0){
			//检测
			  
			collider.enabled = false;
		RaycastHit2D hit=	 Physics2D.Linecast(targetPos, targetPos + new Vector2(h, v));
			collider.enabled = true;
			if (hit.transform == null){
				targetPos += new Vector2(h, v);

			
				
			}
			else{
				switch (hit.collider.tag){
					case"OutWall" :
						break;
					case"Wall":
						ainmator.SetTrigger("Attack"); 
						hit.collider.SendMessage("TakeDamage");
						break;					
				}
			}	 
			resTimer = 0;//攻击移动都需要休息
		}
	}
	
}
