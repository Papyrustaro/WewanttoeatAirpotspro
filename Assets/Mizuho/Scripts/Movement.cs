using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 0.1f;
    public float jumpForce = 300f;
    public bool isJumping = false;


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
        transform.localPosition += Vector3.left * moveSpeed;
    }

    public void RightMove()
    {
        transform.localPosition += Vector3.right * moveSpeed;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.name=="Stage" && isJumping)
        {
            isJumping = false;
        }
    }
}
