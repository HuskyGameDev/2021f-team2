using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_P2 : MonoBehaviour
{

    Rigidbody2D rb;
    Health testHealth;  //rename this for better context in the future.
    public float speed = 0.5f;
    public float JumpForce = 13;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        testHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal_P2

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
            

        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) //if jump pressed and not currently moving through the air
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1")) //This is debug code. Remove when uneeded. THis is testing the player getting hit.
        {
            testHealth.takeDamage(1);
        }//end debug code.

    }
}
