using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InonoaTest : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Rigidbody2D rigidBody;
    IAttack attack;
    Movement movement;

    void Start()
    {
        print("so sorry");
        rigidBody = GetComponent<Rigidbody2D>();
        attack = GetComponent<AttackSword>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            attack.Attack(movement, () => print("働きたくないでござる"));
        }
    }
}
