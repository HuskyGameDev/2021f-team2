using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator animator;

    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
   private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        animator.SetFloat("speed", Mathf.Abs(movement));

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }

    }

}
