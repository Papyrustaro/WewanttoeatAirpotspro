using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardAI : MonoBehaviour
{
    BoardMovement movement;
    PlayerCharacter player;
    new Rigidbody2D rigidbody;
    
    Vector3 playerPosDelayed = Vector2.zero;
    [SerializeField] float tracePlayerDelay = 0.3f;

    [SerializeField] float moveOnGroundSecsMax = 2f;
    [SerializeField] float stopThreshold = 1;
    [SerializeField] float jumpToFloat = 0.4f;
    
    void Start()
    {
        player = PlayerCharacter.Instance;
        movement = GetComponent<BoardMovement>();
        rigidbody = GetComponent<Rigidbody2D>();
        DOVirtual.DelayedCall(0.5f, () => StartCoroutine(LoopOnce()));
    }


    IEnumerator LoopOnce()
    {
        float timeOnGround = 0;
        while((timeOnGround += Time.deltaTime) <= moveOnGroundSecsMax)
        {
            if(transform.position.x + stopThreshold < playerPosDelayed.x)
            {
                rigidbody.velocity = new Vector2(- movement.HorizontalMoveSpeed, rigidbody.velocity.y);
            }
            else if(transform.position.x - stopThreshold > playerPosDelayed.x)
            {
                rigidbody.velocity = new Vector2(  movement.HorizontalMoveSpeed, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        movement.Jump();

        yield return new WaitForSeconds(jumpToFloat);

        movement.StartFloat();
        if(transform.position.x < playerPosDelayed.x)
        {
            rigidbody.velocity = new Vector2(  movement.HorizontalMoveSpeed, 0);
        }
        else
        {
            rigidbody.velocity = new Vector2(- movement.HorizontalMoveSpeed, 0);
        }

        yield return new WaitForSeconds(movement.CanFloatAirTime);

        movement.StopFloat();

        yield return new WaitUntil(() => movement.IsGrounded);

        StartCoroutine(LoopOnce());
    }

    void Update()
    {
        Vector3 currentPlayerPos = player.transform.position;
        StartCoroutine(SantaroCoroutineManager.DelayMethod(
            tracePlayerDelay, () => playerPosDelayed = currentPlayerPos));
    }
}
