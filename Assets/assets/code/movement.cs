using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float JumpingPower;
    public bool isFacingright = true;
    public static int Direction;
    //[SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    void Update()
    {
        //run
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        //anim.SetBool("run", horizontal != 0);
        // jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
           // anim.SetBool("jump", true);
        }
        



        //flip
        if (isFacingright)
        {
            Direction = 1;
        }
        else
        {
            Direction = -1;
        }
        Flip();
    }

    private void Flip()
    {
        if (isFacingright && horizontal > 0f || !isFacingright && horizontal < 0f)
        {
            isFacingright = !isFacingright;
            float tempScale = transform.localScale.x * -1;
            transform.localScale = new Vector3(tempScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
        
    }
}
