using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovableFloor : MonoBehaviour
{
    Sequence mySequence;
    
    private void Start()
    {
        float startX = transform.position.x;
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(10, GetDuration(Mathf.Abs(startX-10))).SetEase(Ease.Linear));
        mySequence.Append(transform.DOMoveX(-10,GetDuration(20)).SetEase(Ease.Linear));
        mySequence.Append(transform.DOMoveX(startX, GetDuration(Mathf.Abs(-10- startX))).SetEase(Ease.Linear));
        mySequence.SetLoops(-1);
    }

    private float GetDuration(float distance)
    {
        return distance * 3 / 10;
    }
}
