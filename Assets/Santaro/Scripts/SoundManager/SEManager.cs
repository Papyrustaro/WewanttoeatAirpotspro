using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// これをAudioSourceが入ったgameObjectにアタッチ。dontDestroyにも...??
/// </summary>
public class SEManager : MonoBehaviour
{
    public static AudioSource audioSource;

    public static AudioClip jump;
    public static AudioClip slash;
    public static AudioClip defeatEnemy;
    public static AudioClip guard;

    private void Awake()
    {
        SEManager.audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySE(AudioClip audioClip, float _volumeScale = 1.0f)
    {
        SEManager.audioSource.PlayOneShot(audioClip, volumeScale: _volumeScale);
    }

    public static void PlaySE(E_SE seType, float _vomumeScale = 1.0f)
    {
        SEManager.audioSource.PlayOneShot(GetAudioClip(seType), volumeScale: _vomumeScale);
    }
    public static AudioClip GetAudioClip(E_SE seType)
    {
        switch (seType)
        {
            case E_SE.Jump:
                return jump;
            case E_SE.Slash:
                return slash;
            case E_SE.DefeatEnemy:
                return defeatEnemy;
            case E_SE.Guard:
                return guard;
        }
        throw new System.Exception();
    }
    public enum E_SE
    {
        Jump,
        Slash,
        DefeatEnemy,
        Guard,
    }
}
