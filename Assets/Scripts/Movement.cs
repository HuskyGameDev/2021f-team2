using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    Health testHealth;  //rename this for better context in the future.
    public float speed = 3.5f;
    public float JumpForce = 13;
<<<<<<< Updated upstream
=======
    public Animator animator;

    AudioSource audioSource;
    bool isMoving = false;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        testHealth = GetComponent<Health>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); 

        Vector3 movement = new Vector3(inputX, 0f, 0f);

        transform.position += (Time.deltaTime * speed * movement);

        if (rb.velocity.x != 0)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
        }
        else
        {
            audioSource.Stop();
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
