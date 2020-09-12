using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackBoomerang : MonoBehaviour, IAttack
{
    [SerializeField] Boomerang boomerang;

    void Start()
    {
        
    }

    public void Attack(Movement movement, Action onFinished)
    {
        Boomerang bmrg = Instantiate(boomerang, this.transform);
        bmrg.OnThrown(() => 
        {
            Destroy(bmrg.gameObject);
            onFinished.Invoke();
        });
    }
}
