using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moement : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;
    public Animator animator;
    public bool isGrounded = false;

    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
   private void Start()
    {
        isGrounded = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        //animator.SetBool("isPunch", false);
        if (isGrounded == true)
            animator.SetBool("isGrounded", true);
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        animator.SetFloat("speed", Mathf.Abs(movement));

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            animator.SetBool("isGrounded", false);
        }
        if (isGrounded == false)
        {
            animator.SetBool("isJump", false);

        }
       /* if (Input.GetKey("up") && isGrounded == true)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * 0;
            animator.SetBool("isPunch", true);
        }*/


       
    }
    void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                print("Grounded");
            }
        }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            print("Not Grounded");
        }
    }
}
