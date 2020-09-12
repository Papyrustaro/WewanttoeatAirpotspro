using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Boomerang : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] float moveDistance = 5f;
    [SerializeField] float moveSeconds = 4f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnThrown(Action onCatched)
    {
        Sequence moveSeq = DOTween.Sequence();
        moveSeq.Append(
            rigidbody2D.DOMoveX(moveDistance, moveSeconds / 2)
            .SetRelative()
            .SetEase(Ease.OutSine)
        );
        moveSeq.Append(
            rigidbody2D.DOMoveX(-moveDistance, moveSeconds / 2)
            .SetRelative()
            .SetEase(Ease.InSine)
        );

        moveSeq.onComplete += () =>
        {
            onCatched.Invoke();
        };
    }

    void Update()
    {
        
    }
}
