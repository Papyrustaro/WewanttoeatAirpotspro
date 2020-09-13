using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageManager : MonoBehaviour
{
    /// <summary>
    /// 各ステージ(プレイヤー以外のすべてのGameObject)
    /// </summary>
    [SerializeField] private GameObject[] stagePrefabs = new GameObject[10];

    /// <summary>
    /// 各ステージのプレイヤーの初期位置
    /// </summary>
    [SerializeField] private Vector3[] playerInitPositions = new Vector3[12];
    [SerializeField] private GameObject playerPrefab;

    /// <summary>
    /// 現在のレベル(階層、数字)0から。
    /// </summary>
    public int CurrentLevel { get; private set; } = 0;

    /// <summary>
    /// 一回のプレイでの、経過時間。
    /// </summary>
    public float CountAllTime { get; private set; } = 0f;


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

    private void Update()
    {
        this.CountAllTime += Time.deltaTime;
    }

    /// <summary>
    /// プレイヤーが勝った時の処理。stagePrefabの切り替え。playerGameObjectの初期化
    /// </summary>
    public void PlayerWin()
    {
        //SceneManager.LoadScene("DemoGameClear");
        Debug.Log("PlayerWin");
        this.stagePrefabs[this.CurrentLevel].SetActive(false);
        this.CurrentLevel++;
        if(this.CurrentLevel > this.stagePrefabs.Length - 1)
        {
            this.GameClear();
            return;
        }
        this.stagePrefabs[this.CurrentLevel].SetActive(true);
        //this.playerPrefab.transform.position = this.playerInitPositions[this.CurrentLevel];

    }

    /// <summary>
    /// 全てのステージをクリアしたときの処理
    /// </summary>
    public void GameClear()
    {
        SceneManager.LoadScene("DemoGameClear");
        /*Debug.Log("全ステージクリア(経過時間: " + this.CountAllTime);*/
    }

    /// <summary>
    /// プレイヤーが負けたときの処理。とりあえず別のシーンに遷移
    /// </summary>
    public void PlayerLose()
    {
        /*Debug.Log("PlayerLose");*/
        SceneManager.LoadScene("DemoGameOver");
    }
    
}
