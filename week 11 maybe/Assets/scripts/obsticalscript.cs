using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticalscript : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.name.Contains("Player"))
    {
        gamemanager.instance.GetComponent<asciilevelloader>().ResetPlayer();
    }
   }
}
