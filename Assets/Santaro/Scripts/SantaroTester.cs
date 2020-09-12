using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaroTester : MonoBehaviour
{
    private Movement _movement;
    [SerializeField] private IAttack _attack;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _attack = GetComponent<IAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _attack.Attack(_movement, () => { });
        }
    }
}
