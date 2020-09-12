using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 100f;
    public float jumpForce = 300f;
    public bool isJumping = false;
    public enum BodyDirection
    {
        Left, Right
    }
    public BodyDirection currentBodyDirection { get; private set; }

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
    }

    public void LeftMove()
    {
        //transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;
        //rb2D.velocity += (Vector2)Vector3.left * moveSpeed * Time.deltaTime;
        //rb2D.velocity = new Vector2(Vector3.left.x * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = new Vector2(rb2D.velocity.x +  Vector3.left.x * moveSpeed, rb2D.velocity.y);
        currentBodyDirection = BodyDirection.Left;
    }

    public void RightMove()
    {
        //transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
        //rb2D.velocity += (Vector2)Vector3.right * moveSpeed * Time.deltaTime;
        //rb2D.velocity = new Vector2(Vector3.right.x * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = new Vector2(rb2D.velocity.x + Vector3.right.x * moveSpeed, rb2D.velocity.y);
        currentBodyDirection = BodyDirection.Right;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb2D.AddForce(transform.up * jumpForce);
        }

    }

    public void Guard()
    {

    }

    public void Stop()
    {
        rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag=="Stage" && isJumping)
        {
            isJumping = false;
        }
        if (other.transform.tag == "MovingStage")
        {
            if (isJumping)
            {
                isJumping = false;
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
