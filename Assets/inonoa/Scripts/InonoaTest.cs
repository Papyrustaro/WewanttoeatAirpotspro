using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InonoaTest : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Rigidbody2D rigidBody;

    void Start()
    {
        print("so sorry");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }
}
