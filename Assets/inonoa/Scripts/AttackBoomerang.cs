using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class AttackBoomerang : MonoBehaviour, IAttack
{
    [SerializeField] Boomerang boomerang;

    void Start()
    {
        
    }

    public void Attack(Movement movement, Action onFinished)
    {
        Boomerang bmrg = Instantiate(boomerang, this.transform);
        bmrg.OnThrown(false, () =>
        {
            Destroy(bmrg.gameObject);
            onFinished.Invoke();
        });
        
        //出現した瞬間自身と衝突して消滅するのを回避、かなりその場しのぎ
        DOVirtual.DelayedCall(0.2f, () => bmrg.GetComponent<Collider2D>().enabled = true);
    }
}
