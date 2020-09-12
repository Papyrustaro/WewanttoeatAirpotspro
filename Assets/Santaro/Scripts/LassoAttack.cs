using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 投げ縄生成と、初期速度代入。
/// </summary>
public class LassoAttack : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject lassoObject;
    [SerializeField] private Transform rightLassoInstantiatePosition;
    [SerializeField] private Transform leftLassoInstantiatePosition;

    public void Attack(Movement movement, Action onFinish)
    {
        if(movement.currentBodyDirection == Movement.BodyDirection.Left)
        {

        }
        else
        {

        }
    }
}
