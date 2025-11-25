using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalscript : MonoBehaviour
{
    private void OnCollisionEnter2D()
        {
            //increase the scene property in the ascii level loader
            gamemanager.instance.GetComponent<asciilevelloader>().CurrentLevel ++;
            gamemanager.instance.GetComponent<asciilevelloader>().ResetPlayer();
        }
    
}
