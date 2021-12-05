using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    One = 1,
    Two = 2
}

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    Health testHealth;  //rename this for better context in the future.
    public float speed = 3.5f;
    public float JumpForce = 13;
    Animator animator;
    public Player PlayerNumber;
    public bool p2Blocking = false;
    public bool p1Blocking  = false;
    public float p2blockTimer = 0.25f;
    public float p1blockTimer = 2f;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        testHealth = GetComponent<Health>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerNumber == Player.One)
        {
            float inputX = Input.GetAxis("Player 1 Horizontal");

            Vector3 movement = new Vector3(inputX, 0f, 0f);

            transform.position += (Time.deltaTime * speed * movement);

            if (Input.GetButtonDown("Player 1 Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) //if jump pressed and not currently moving through the air
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            if (Input.GetButtonDown("Player 1 Fire"))
            {
                //What we want to add is a way to prevent users from mashing the Fire1 button
                //And a way to stop player movement
                animator.SetTrigger("punchButton");
                Debug.Log("P1 Punch!");
                //testHealth.takeDamage(1);
            }

            if (Input.GetButton("Player 1 Block")) //Simple test code, will block if S is pressed
            {
                animator.SetTrigger("blockButton");

                p1Blocking = true;
                Debug.Log("P1 is Blocking!");

                /*
                while (p1blockTimer > 0)
                {
                    p1blockTimer -= Time.deltaTime;

                }
                if (p1blockTimer == 0)
                {
                    p1Blocking = false;
                    p1blockTimer = 2f;
                    Debug.Log("P1 is done Blocking!");
                }
                */


               
            }
        }




        if (PlayerNumber == Player.Two)
        {
            float inputX = Input.GetAxis("Player 2 Horizontal");

            Vector3 movement = new Vector3(inputX, 0f, 0f);

            transform.position += (Time.deltaTime * speed * movement);

            if (Input.GetButtonDown("Player 2 Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) //if jump pressed and not currently moving through the air
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            if (Input.GetButtonDown("Player 2 Fire"))
            {
                //What we want to add is a way to prevent users from mashing the Fire1 button
                //And a way to stop player movement
                animator.SetTrigger("punchButton");
                Debug.Log("P2 Punch!");
                //testHealth.takeDamage(1);
            }

            if (Input.GetKeyDown("Player 2 Block")) //Simple test code, will block if S is pressed
            {
                animator.SetTrigger("blockButton");

                p2Blocking = true;
                
                while(p2blockTimer > 0)
                {
                    p2blockTimer -= Time.deltaTime;

                }
                if (p2blockTimer == 0)
                {
                    p2Blocking = false;
                    p2blockTimer = 0.25f;
                }
                
                Debug.Log("P2 Block!");
            }
        }

        while (p1blockTimer > 0 && p1Blocking == true)
        {
            p1blockTimer -= Time.deltaTime;
            Debug.Log("While loop");

        }
        if (p1blockTimer <= 0)
        {
            p1Blocking = false;
            p1blockTimer = 2f;
            Debug.Log("P1 is done Blocking!");
        }

    }
}
