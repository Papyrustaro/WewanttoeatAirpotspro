using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    public void OnThrown(bool toRight)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(toRight ? speed : -speed, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
