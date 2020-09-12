using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class AttackArrow : MonoBehaviour, IAttack
{
    [SerializeField] Arrow arrowPrefab;

    public void Attack(Movement movement, Action onFinished)
    {
        Arrow arrow = Instantiate(arrowPrefab, transform);
        arrow.OnThrown(movement.currentBodyDirection == Movement.BodyDirection.Right);

        DOVirtual.DelayedCall(0.2f, () => 
        {
            arrow.GetComponent<Collider2D>().enabled = true;
            onFinished.Invoke();
        });
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
