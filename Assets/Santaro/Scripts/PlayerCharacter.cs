using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Movement _movement;
    private IAttack _attacker; //無い場合は処理しない
    private bool haveAttacker = false;

    public static PlayerCharacter Instance { get; private set; }

    public Movement M_Movement => _movement;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception();
        }

        _movement = GetComponent<Movement>();
        _attacker = GetComponent<IAttack>();
        if (_attacker != null) this.haveAttacker = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && this.haveAttacker)
        {
            _attacker.Attack(_movement, () => { });
        }
    }

    /// <summary>
    /// !haveAttackerのときAttackを呼ばないでも良い
    /// </summary>
    public void Attack()
    {
        if (!haveAttacker) return;
    }
}
