using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Boomerang : MonoBehaviour
{
    public void OnThrown(Action onCatched)
    {
        this.gameObject.SetActive(true);
        DOVirtual.DelayedCall(1f, () =>
        {
            this.gameObject.SetActive(false);
            onCatched.Invoke();
        });
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
