using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingAI : MonoBehaviour
{
    [SerializeField] float tracePlayerDelay = 1.5f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float stopThreshold = 1;
    Vector3 delayedPlayerPos = Vector3.zero;
    new Rigidbody2D rigidbody;

    void Start()
    {
        delayedPlayerPos = PlayerCharacter.Instance.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 currentPlayerPos = PlayerCharacter.Instance.transform.position;
        StartCoroutine(SantaroCoroutineManager.DelayMethod(tracePlayerDelay, () => delayedPlayerPos = currentPlayerPos));

        if(transform.position.x + stopThreshold < delayedPlayerPos.x)
        {
            rigidbody.velocity = new Vector2( moveSpeed, rigidbody.velocity.y);
        }
        else if(transform.position.x - stopThreshold > delayedPlayerPos.x)
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(         0, rigidbody.velocity.y);
        }
    }
}
