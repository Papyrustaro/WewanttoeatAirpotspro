using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボード。ジャンプしてから一定時間浮くことができる。踏みつけることで攻撃できる
/// </summary>
public class BoardMovement : MonoBehaviour
{
    [SerializeField] private float horizontalMoveSpeed = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float canFloatAirTime = 1f;
    private Rigidbody2D _rigidbody2D;
    private float defaultGravity;
    private bool inputRight = false;
    private bool inputLeft = false;
    private bool waitJump = false;
    private bool useFloat = false;
    private float countFloatTime = 0f;

    /// <summary>
    /// colliderを別で用意して、接地判定
    /// </summary>
    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        this.defaultGravity = _rigidbody2D.gravityScale;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.inputLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            this.inputRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.inputLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.inputRight = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && this.IsGrounded && _rigidbody2D.velocity.y > -0.1f)
        {
            this.waitJump = true;
        }

        if(!this.IsGrounded && !this.useFloat && Input.GetKeyDown(KeyCode.W))
        {
            this.StartFloat();
        }
        if(_rigidbody2D.gravityScale == 0f && Input.GetKeyUp(KeyCode.W))
        {
            this.StopFloat();
        }

        if (_rigidbody2D.gravityScale == 0f)
        {
            this.countFloatTime += Time.deltaTime;
            if(this.countFloatTime > this.canFloatAirTime)
            {
                this.StopFloat();
            }
        }

    }

    private void FixedUpdate()
    {
        if (this.inputRight && !this.inputLeft)
        {
            _rigidbody2D.velocity = new Vector2(this.horizontalMoveSpeed, _rigidbody2D.velocity.y);
        }
        else if (!this.inputRight && this.inputLeft)
        {
            _rigidbody2D.velocity = new Vector2(-this.horizontalMoveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
        }

        if(this.waitJump)
        {
            this.waitJump = false;
            this.IsGrounded = false;
            //_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 10f);
            _rigidbody2D.AddForce(Vector2.up * this.jumpForce);
        }
    }

    public void StartFloat()
    {
        this.useFloat = true;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
        _rigidbody2D.gravityScale = 0f;
    }

    public void StopFloat()
    {
        _rigidbody2D.gravityScale = this.defaultGravity;
        this.countFloatTime = 0f;
    }

    public void OnGrounded()
    {
        this.IsGrounded = true;
        this.useFloat = false;
        this.countFloatTime = 0f;
        _rigidbody2D.gravityScale = this.defaultGravity;
    }
}
