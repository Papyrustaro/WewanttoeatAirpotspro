using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// アタッチすると、Sでガードできる。
/// </summary>
public class ShieldGuard : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Vector3 shieldRightLocalPositionInGurad;
    [SerializeField] private BoxCollider2D shieldCollider;
    [SerializeField] private Movement movement;
    private Vector3 defaultShieldLocalPosition;

    private void Awake()
    {
        this.defaultShieldLocalPosition = this.shieldObject.transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.movement.canMove = false;
            this.shieldCollider.enabled = true;
            if(movement.currentBodyDirection == Movement.BodyDirection.Right)
            {
                this.shieldObject.transform.localPosition = this.shieldRightLocalPositionInGurad;
            }
            else
            {
                this.shieldObject.transform.localPosition = new Vector3(-this.shieldRightLocalPositionInGurad.x, this.shieldRightLocalPositionInGurad.y, 0f);
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.shieldObject.transform.localPosition = this.defaultShieldLocalPosition;
            this.movement.canMove = true;
            this.shieldCollider.enabled = false;
        }
    }
}
