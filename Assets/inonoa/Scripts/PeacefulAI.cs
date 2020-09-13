using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PeacefulAI : MonoBehaviour
{
    [SerializeField] float waitSeconds = 1;
    [SerializeField] float jumpRate = 0.3f;
    [SerializeField] float goAwaySecondsMax = 2f;

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
        
        float time = 0;
        float farFromPlayerThreshold = 4f;
        while(Vector2.Distance(transform.position, playerPosDelayed) < farFromPlayerThreshold)
        {
            if(transform.position.x < playerPosDelayed.x)
            {
                movement.LeftMove();
            }
            else
            {
                movement.RightMove();
            }

            time += Time.deltaTime;
            if(time >= goAwaySecondsMax)
            {
                break;
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
        DOVirtual.DelayedCall(tracePlayerDelay, () => playerPosDelayed = currentPlayerPos);
    }
}
