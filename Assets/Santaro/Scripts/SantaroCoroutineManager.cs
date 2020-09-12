using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SantaroCoroutineManager : MonoBehaviour
{
    public static IEnumerator DelayMethodRealTime(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public static IEnumerator DelayMethodRealTime(int delayFrameCount, Action action)
    {
        for (int i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
}
