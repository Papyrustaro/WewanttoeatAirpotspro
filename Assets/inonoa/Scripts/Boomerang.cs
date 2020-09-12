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

    Action onCatched;
    Sequence moveSeq;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnThrown(bool toRight, Action onCatched)
    {
        this.onCatched = onCatched;

        moveSeq = DOTween.Sequence();
        moveSeq.Append(
            rigidbody2D.DOMoveX(toRight ? moveDistance : -moveDistance, moveSeconds / 2)
            .SetRelative()
            .SetEase(Ease.OutSine)
        );
        moveSeq.Append(
            rigidbody2D.DOMoveX(toRight ? -moveDistance : moveDistance, moveSeconds / 2)
            .SetRelative()
            .SetEase(Ease.InSine)
        );

        moveSeq.onComplete += () =>
        {
            onCatched.Invoke();
        };
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Contains("Player") || other.gameObject.tag.Contains("Enemy"))
        {
            onCatched.Invoke();
        }
        else
        {
            moveSeq.timeScale *= -1;
        }
    }
}
