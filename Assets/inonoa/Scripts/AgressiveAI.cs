using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AgressiveAI : MonoBehaviour
{
    [SerializeField] float waitSeconds = 1;
    [SerializeField] float jumpRate = 0.3f;

    PlayerCharacter player;
    Movement movement;
    IAttack attack;
    IGuard guard;
    [SerializeField] float guardRate = 0.3f;

    Vector3 playerPosDelayed = Vector2.zero;
    [SerializeField] float tracePlayerDelay = 0.3f;

    void Start()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<IAttack>();
        guard = GetComponent<IGuard>();
        player = PlayerCharacter.Instance;
        DOVirtual.DelayedCall(0.5f, () => StartCoroutine(LoopOnce()));
        playerPosDelayed = player.transform.position;
    }

    IEnumerator LoopOnce()
    {
        if(Random.Range(0f, 1f) < jumpRate)
        {
            movement.Jump();
        }

        float nearPlayerThreshold = 1.3f;
        while(Vector2.Distance(transform.position, playerPosDelayed) > nearPlayerThreshold)
        {
            if(transform.position.x < playerPosDelayed.x)
            {
                movement.RightMove();
            }
            else
            {
                movement.LeftMove();
            }
            yield return null;
        }

        movement.Stop();

        yield return new WaitForSeconds(waitSeconds);

        if(      guard == null) Attack();
        else if(attack == null) Guard();
        else
        {
            if(Random.Range(0f, 1f) < guardRate) Guard();
            else                                 Attack();
        }
    }

    void Attack()
    {
        attack.Attack(movement, () =>
        {
            float afterAttack = Random.Range(0.5f, 1f);
            DOVirtual.DelayedCall(afterAttack, () => StartCoroutine(LoopOnce()));
        });
    }
    void Guard()
    {
        guard?.Guard(movement, () =>
        {
            float afterGuard = Random.Range(0.5f, 1f);
            DOVirtual.DelayedCall(afterGuard, () => StartCoroutine(LoopOnce()));
        });
    }
    void Update()
    {
        Vector3 currentPlayerPos = player.transform.position;
        StartCoroutine(SantaroCoroutineManager.DelayMethod(
            tracePlayerDelay, () => playerPosDelayed = currentPlayerPos));
    }
}
