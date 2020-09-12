using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SantaroTransformManager : MonoBehaviour
{
    /// <summary>
    /// 自分のgameObjectが中心にいないときの一定時間で一定角度回転処理
    /// </summary>
    /// <param name="obj">回転させるtransform</param>
    /// <param name="centerPosition">実際の回転中心transform</param>
    /// <param name="angle">回転角度</param>
    /// <param name="time">回転時間</param>
    /// <returns></returns>
    public static IEnumerator RotateInCertainTimeByAxisFromAway(Transform obj, Transform centerPosition, float angle, float time, Action onFinish)
    {
        float countTime = 0f;

        //回転処理
        while (countTime < time)
        {
            yield return null;
            countTime += Time.deltaTime;
            obj.RotateAround(centerPosition.position, Vector3.forward, angle * Time.deltaTime / time);
        }

        //超過分修正
        obj.RotateAround(centerPosition.position, Vector3.forward, -1 * angle * (countTime - time) / time);
        onFinish.Invoke();
        yield break;
    }

    /// <summary>
    /// 自分のgameObjectが中心にいないときの一定時間で一定角度回転処理
    /// </summary>
    /// <param name="obj">回転させるtransform</param>
    /// <param name="centerPosition">実際の回転中心transform</param>
    /// <param name="angle">回転角度</param>
    /// <param name="time">回転時間</param>
    /// <returns></returns>
    public static IEnumerator RotateInCertainTimeByAxisFromAway(Transform obj, Transform targetTransform, Vector3 diffCenterAndTarget, float angle, float time, Action onFinish)
    {
        float countTime = 0f;

        //回転処理
        while (countTime < time)
        {
            yield return null;
            countTime += Time.deltaTime;
            obj.RotateAround(targetTransform.position + diffCenterAndTarget, Vector3.forward, angle * Time.deltaTime / time);
        }

        //超過分修正
        obj.RotateAround(targetTransform.position + diffCenterAndTarget, Vector3.forward, -1 * angle * (countTime - time) / time);
        onFinish.Invoke();
        yield break;
    }
}
