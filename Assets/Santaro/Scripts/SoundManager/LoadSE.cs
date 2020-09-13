using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSE : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSE;
    [SerializeField] private AudioClip slashSE;
    [SerializeField] private AudioClip defeatEnemySE;
    [SerializeField] private AudioClip guardSE;

    private void Awake()
    {
        SEManager.jump = this.jumpSE;
        SEManager.slash = this.slashSE;
        SEManager.defeatEnemy = this.defeatEnemySE;
        SEManager.guard = this.guardSE;
    }
}
