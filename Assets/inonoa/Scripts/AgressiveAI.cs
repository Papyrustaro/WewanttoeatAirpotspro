﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AgressiveAI : MonoBehaviour
{
    [SerializeField] float waitSeconds = 1;

    PlayerCharacter player;
    Movement movement;
    IAttack attack;

    void Start()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<IAttack>();
        player = PlayerCharacter.Instance;
        StartCoroutine(LoopOnce());
    }

    IEnumerator LoopOnce()
    {
        float nearPlayerThreshold = 1.5f;
        while(Vector2.Distance(transform.position, player.transform.position) > nearPlayerThreshold)
        {
            if(transform.position.x < player.transform.position.x)
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
        
    }
}
