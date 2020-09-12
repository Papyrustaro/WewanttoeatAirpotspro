using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ホッピング用のmovementクラス。
/// </summary>
public class HoppingMovement : MonoBehaviour
{
    [SerializeField] private float horizontalMoveSpeed = 3f;
    private Rigidbody2D _rigidbody2D;
    private bool inputRight = false;
    private bool inputLeft = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        
    }

    private void FixedUpdate()
    {
        if(this.inputRight && !this.inputLeft)
        {
            _rigidbody2D.velocity = new Vector2(this.horizontalMoveSpeed, _rigidbody2D.velocity.y);
        }
        else if(!this.inputRight && this.inputLeft)
        {
            _rigidbody2D.velocity = new Vector2(-this.horizontalMoveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
        }
    }
}
