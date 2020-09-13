using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();

        if (!canMove)
        {
            Stop();
            return;
        }

        
        if (Input.GetKey(KeyCode.S))
        {
            Guard();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            LeftMove();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RightMove();
        }
        else
        {
            Stop();
        }
    }

}
