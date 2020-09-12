using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 鉤爪攻撃、基本は剣と同じ。少しリーチが短く、攻撃速度も速い
/// </summary>
public class ClawsAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Vector3 initClawsLocalPositionInRight = new Vector3(0.2f, 0.5f, 0f);
    [SerializeField] private GameObject clawsObject;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float oneSlashTime = 0.1f;
    [SerializeField] private float intervalFromFinishSlash = 0.1f;
    private bool canSlash = true;

    public void Attack(Movement movement, Action onFinish)
    {
        if (!this.canSlash) return;
        this.canSlash = false;
        Vector3 defaultLocalClawsPosition = this.clawsObject.transform.localPosition;
        Quaternion defaultLocalClawsRotation = this.clawsObject.transform.localRotation;
        if (movement.currentBodyDirection == Movement.BodyDirection.Right)
        {
            this.clawsObject.transform.localPosition = this.initClawsLocalPositionInRight;
            StartCoroutine(SantaroTransformManager.RotateInCertainTimeByAxisFromAway(this.clawsObject.transform, this.playerObject.transform, -120f, this.oneSlashTime, () => {
                onFinish.Invoke();
                this.clawsObject.transform.localPosition = defaultLocalClawsPosition;
                this.clawsObject.transform.localRotation = defaultLocalClawsRotation;
            }));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime + this.intervalFromFinishSlash, () => this.canSlash = true));
        }
        else
        {
            this.clawsObject.transform.localPosition = new Vector3(-this.initClawsLocalPositionInRight.x, this.initClawsLocalPositionInRight.y, 0f);
            StartCoroutine(SantaroTransformManager.RotateInCertainTimeByAxisFromAway(this.clawsObject.transform, this.playerObject.transform, 120f, this.oneSlashTime, () => {
                onFinish.Invoke();
                this.clawsObject.transform.localPosition = defaultLocalClawsPosition;
                this.clawsObject.transform.localRotation = defaultLocalClawsRotation;
            }));
            StartCoroutine(SantaroCoroutineManager.DelayMethod(this.oneSlashTime + this.intervalFromFinishSlash, () => this.canSlash = true));
        }

    }
}
