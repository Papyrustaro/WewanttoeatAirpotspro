using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 6f;
    public float jumpForce = 500f;
    public bool isJumping = false;
    public enum BodyDirection
    {
        Left, Right
    }
    public BodyDirection currentBodyDirection { get; private set; }

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        //need Rigidbody2D and BoxCollider
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        //need Animator
        animator = GetComponent<Animator>();

        //sprite
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
    }

    public void LeftMove()
    {
        //transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;
        //rb2D.velocity += (Vector2)Vector3.left * moveSpeed * Time.deltaTime;
        rb2D.velocity = new Vector2(Vector3.left.x * moveSpeed, rb2D.velocity.y);
        //rb2D.velocity = new Vector2(rb2D.velocity.x +  Vector3.left.x * moveSpeed, rb2D.velocity.y);
        currentBodyDirection = BodyDirection.Left;

        if (transform.tag == "Player")
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isGuard", false);
            animator.SetBool("isWalk", true);
            renderer.flipX = true;
        }
    }

    public void RightMove()
    {
        //transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
        //rb2D.velocity += (Vector2)Vector3.right * moveSpeed * Time.deltaTime;
        rb2D.velocity = new Vector2(Vector3.right.x * moveSpeed, rb2D.velocity.y);
        //rb2D.velocity = new Vector2(rb2D.velocity.x + Vector3.right.x * moveSpeed, rb2D.velocity.y);
        currentBodyDirection = BodyDirection.Right;
        if (transform.tag == "Player")
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isGuard", false);
            animator.SetBool("isWalk", true);
            renderer.flipX = false;
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb2D.AddForce(transform.up * jumpForce);
        }
        if (transform.tag == "Player")
        {
            animator.SetBool("isJump",true);
            animator.SetBool("isAttack", false);
            animator.SetBool("isGuard", false);
        }
    }

    public void Guard()
    {
        if(transform.tag == "Player")
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isGuard", true);
        }
    }

    public void Attack()
    {
        if (transform.tag == "Player")
        {
            animator.SetBool("isAttack", true);
        }
    }

    public void Stop()
    {
        rb2D.velocity = new Vector2(0f, rb2D.velocity.y);

        if (transform.tag == "Player")
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isGuard", false);
            animator.SetBool("isWalk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag=="Stage" && isJumping)
        {
            isJumping = false;
            animator.SetBool("isJump", false);

        }
        if (other.transform.tag == "MovingStage")
        {
            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("isJump",false);
            }
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingStage")
        {
            transform.SetParent(null);
        }
    }
}
