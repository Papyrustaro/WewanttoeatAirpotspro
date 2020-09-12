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

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.A))
        {
            LeftMove();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Guard();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RightMove();
        }
    }

}
