using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageManager : MonoBehaviour
{
    /// <summary>
    /// 各ステージ(プレイヤー以外のすべてのGameObject)
    /// </summary>
    [SerializeField] private GameObject[] stagePrefabs = new GameObject[12];

    /// <summary>
    /// 各ステージのプレイヤーの初期位置
    /// </summary>
    [SerializeField] private Vector3[] playerInitPositions = new Vector3[12];
    [SerializeField] private GameObject playerPrefab;

    /// <summary>
    /// 現在のレベル(階層、数字)0から。
    /// </summary>
    public int CurrentLevel { get; private set; } = 0;


    public static GameStageManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception();
        }
    }

    /// <summary>
    /// プレイヤーが勝った時の処理。stagePrefabの切り替え。playerGameObjectの初期化
    /// </summary>
    public void PlayerWin()
    {
        Debug.Log("PlayerWin");
        this.stagePrefabs[this.CurrentLevel].SetActive(false);
        this.CurrentLevel++;
        this.stagePrefabs[this.CurrentLevel].SetActive(true);
        this.playerPrefab.transform.position = this.playerInitPositions[this.CurrentLevel];

    }

    /// <summary>
    /// プレイヤーが負けたときの処理。とりあえず別のシーンに遷移
    /// </summary>
    public void PlayerLose()
    {
        Debug.Log("PlayerLose");
        SceneManager.LoadScene("GameOver");
    }
    
}
