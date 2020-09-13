using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 投げ縄生成と、初期速度代入。LassoObjectはRigidbody2Dをアタッチ
/// </summary>
public class LassoAttack : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject lassoObject;
    [SerializeField] private Transform rightLassoInstantiatePosition;
    [SerializeField] private Transform leftLassoInstantiatePosition;
    [SerializeField] private float throwInterval = 3f;
    [SerializeField] private float throwAngle = 30f;
    [SerializeField] private float throwPower = 10f;
    private bool canThrowLasso = true;


    public void Attack(Movement movement, Action onFinish)
    {
        if (!this.canThrowLasso) return;
        this.canThrowLasso = false;
        StartCoroutine(SantaroCoroutineManager.DelayMethod(this.throwInterval, () => this.canThrowLasso = true));

        if(movement.currentBodyDirection == Movement.BodyDirection.Left)
        {
            GameObject lasso = Instantiate(this.lassoObject, this.leftLassoInstantiatePosition.position, Quaternion.identity);
            lasso.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0f, 0f, this.throwAngle) * Vector2.up * this.throwPower, ForceMode2D.Impulse);
        }
        else
        {
            GameObject lasso = Instantiate(this.lassoObject, this.rightLassoInstantiatePosition.position, Quaternion.identity);
            lasso.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0f, 0f, -this.throwAngle) * Vector2.up * this.throwPower, ForceMode2D.Impulse);
        }
        onFinish.Invoke();
    }
}
