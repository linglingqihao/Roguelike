using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
   public int hp = 2;

   public Sprite damagesSprite;//受到攻击的图片
   //自身受到攻击的时候
   public void TakeDamage()
   {
      hp -= 1;
       GetComponent<SpriteRenderer>().sprite = damagesSprite;
       if (hp <= 0)
       {
           Destroy(this.gameObject );
       } 
   }
}
 