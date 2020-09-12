using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class AttackSword : MonoBehaviour, IAttack
{
    public void Attack(Movement movement, Action onFinish)
    {
        DOVirtual.DelayedCall(1, () => onFinish());
    }
}
