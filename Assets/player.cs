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
	
	
	private Vector2 targetPos = new Vector2(1, 1);
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
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

		if (h != 0 || v != 0)
		{


			targetPos += new Vector2(h, v);

			
			resTimer = 0;
		}
	}
	
}
