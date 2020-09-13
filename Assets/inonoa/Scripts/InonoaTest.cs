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
        rigidBody = GetComponent<Rigidbody2D>();
        attack = GetComponent<IAttack>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            attack.Attack(movement, () => {});
        }
    }
}
