using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftMove()
    {
        transform.localPosition += Vector3.forward;
    }

    public void RightMove()
    {
        transform.localPosition -= Vector3.forward;
    }

    public void Jump()
    {

    }

    public void Guard()
    {

    }
}
