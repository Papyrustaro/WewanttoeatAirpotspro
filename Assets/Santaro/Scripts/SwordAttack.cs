using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// 剣による攻撃。リーチも隙も並み。
/// </summary>
public class SwordAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Vector3 initSwordLocalPositionInRight = new Vector3(0.2f, 0.5f, 0f);
    [SerializeField] private GameObject swordObject;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float oneSlashTime = 0.2f;
    [SerializeField] private float intervalFromFinishSlash = 0.2f;
    [SerializeField] private BoxCollider2D _collider;
    private bool canSlash = true;

    public void Attack(Movement movement, Action onFinish)
    {
        if (!this.canSlash) return; 
        this.canSlash = false;
        _collider.enabled = true;
        Vector3 defaultLocalSwordPosition = this.swordObject.transform.localPosition;
        Quaternion defaultLocalSwordRotation = this.swordObject.transform.localRotation;
        if (movement.currentBodyDirection == Movement.BodyDirection.Right)
        {
            this.swordObject.transform.localPosition = this.initSwordLocalPositionInRight;
            StartCoroutine(SantaroTransformManager.RotateInCertainTimeByAxisFromAway(this.swordObject.transform, this.playerObject.transform, -120f, this.oneSlashTime, () => {
                onFinish.Invoke();
                this.swordObject.transform.localPosition = defaultLocalSwordPosition;
                this.swordObject.transform.localRotation = defaultLocalSwordRotation;
            }));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime, () => _collider.enabled = false));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime + this.intervalFromFinishSlash, () =>  this.canSlash = true));
        }
        else
        {
            this.swordObject.transform.localPosition = new Vector3(-this.initSwordLocalPositionInRight.x, this.initSwordLocalPositionInRight.y, 0f);
            StartCoroutine(SantaroTransformManager.RotateInCertainTimeByAxisFromAway(this.swordObject.transform, this.playerObject.transform, 120f, this.oneSlashTime, () => {
                onFinish.Invoke();
                this.swordObject.transform.localPosition = defaultLocalSwordPosition;
                this.swordObject.transform.localRotation = defaultLocalSwordRotation;
            }));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime, () => _collider.enabled = false));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime + this.intervalFromFinishSlash, () => this.canSlash = true));
        }
        
    }

}
