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

    Vector3 playerPosDelayed = Vector2.zero;
    [SerializeField] float tracePlayerDelay = 0.3f;

    void Start()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<IAttack>();
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

        attack.Attack(movement, () =>
        {
            float afterAttack = Random.Range(0.5f, 1f);
            DOVirtual.DelayedCall(afterAttack, () => StartCoroutine(LoopOnce()));
        });
    }


    void Update()
    {
        Vector3 currentPlayerPos = player.transform.position;
        StartCoroutine(SantaroCoroutineManager.DelayMethod(
            tracePlayerDelay, () => playerPosDelayed = currentPlayerPos));
    }
}
