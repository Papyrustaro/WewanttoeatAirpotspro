using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンの入力でサウンドを鳴らすサンプル
/// </summary>
public class SoundTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SEManager.PlaySE(SEManager.E_SE.Slash);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SEManager.PlaySE(SEManager.E_SE.Jump);
        }
    }
}
