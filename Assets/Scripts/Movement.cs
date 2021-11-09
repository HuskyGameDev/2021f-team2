using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    Health testHealth;  //rename this for better context in the future.
    public float speed = 3.5f;
    public float JumpForce = 13;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        testHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(inputX, 0f, 0f);

        transform.position += (Time.deltaTime * speed * movement);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) //if jump pressed and not currently moving through the air
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
           //What we want to add is a way to prevent users from mashing the Fire1 button
           //And a way to stop player movement
            animator.SetTrigger("punchButton");
            Debug.Log("Mouse clicked!");
            //testHealth.takeDamage(1);
        }

        if (Input.GetKeyDown("s")) //Simple test code, will block if S is pressed
        {
            animator.SetTrigger("blockButton");
            Debug.Log("Down pressed!");
        }


    }
}
