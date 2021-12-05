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

            if (Input.GetButton("Player 1 Block"))
            {
                animator.SetTrigger("blockButton");
                Debug.Log("P1 Block!");
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

            if (Input.GetButtonDown("Player 2 Block"))
            {
                animator.SetTrigger("blockButton");
                Debug.Log("P2 Block!");
            }
        }

    }
}
