using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wall : MonoBehaviour
{


 public int hp = 2;

	public Sprite DamageSprite;
	//受到攻击
	
	public void TakeDamage()
	{
		hp -= 1;
		GetComponent<SpriteRenderer>().sprite = DamageSprite;
		if (hp <= 0){
			Destroy(this.gameObject);
		}
	}

}
