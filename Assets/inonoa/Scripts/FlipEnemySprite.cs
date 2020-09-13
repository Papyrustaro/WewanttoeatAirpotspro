using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemySprite : MonoBehaviour
{
    SpriteRenderer renderer;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.x == 0) return;
        renderer.flipX = rigidbody.velocity.x > 0;
    }
}
