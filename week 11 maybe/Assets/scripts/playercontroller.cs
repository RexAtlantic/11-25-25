using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    //variables
    public static playercontroller instance;

    public Rigidbody2D rb;

    public float forceamount = .1f;

    private void Awake()
    {
        
        if(instance == null)
        {
           
            DontDestroyOnLoad(gameObject);
             instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceamount);
        }

        //Make Square move left if A is pressed
        if (Input.GetKey(KeyCode.A))
        { 
            rb.AddForce(Vector2.left * forceamount);
        }

        //Make Square move down if S is pressed
        if (Input.GetKey(KeyCode.S))
        { 
            rb.AddForce(Vector2.down * forceamount);
        }

        //Make Square move right if D is pressed
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * forceamount);
        }
        
        
    }
}
