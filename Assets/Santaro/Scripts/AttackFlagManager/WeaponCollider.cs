using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 全ての攻撃判定にアタッチするクラス。
/// </summary>
public class WeaponCollider : MonoBehaviour
{
    /// <summary>
    /// ガードされたときに、攻撃判定が消える時間
    /// </summary>
    [SerializeField] private float cannotAttackTimeFromGuarded;
    [SerializeField] private Collider2D canAttackCollider;
    private bool isPlayerWeapon;

    private void Awake()
    {
        this.isPlayerWeapon = this.gameObject.CompareTag("AttackOfPlayer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.isPlayerWeapon)
        {
            if (collision.CompareTag("EnemyBody"))
            {
                GameStageManager.Instance.PlayerWin();
            }
            else if (collision.CompareTag("GuardOfEnemy"))
            {
                this.canAttackCollider.enabled = false;
                DOVirtual.DelayedCall(this.cannotAttackTimeFromGuarded, () => this.canAttackCollider.enabled = true)
                    .SetLink(this.gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("PlayerBody"))
            {
                GameStageManager.Instance.PlayerLose();
            }
            else if (collision.CompareTag("GuardOfPlayer"))
            {
                this.canAttackCollider.enabled = false;
                DOVirtual.DelayedCall(this.cannotAttackTimeFromGuarded, () => this.canAttackCollider.enabled = true)
                    .SetLink(this.gameObject);
            }
        }
    }
}
