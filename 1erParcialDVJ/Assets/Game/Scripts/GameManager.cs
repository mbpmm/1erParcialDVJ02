using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int points;
    public float enemiesAlive;

    private bool gameOver;
    private GameObject enemies;
    private EnemyManager enemiesManager;
    private GameObject player;
    private Player playerManager;
    private GameObject trapDoor;
    string key = "123qwe";

    public override void Awake()
    {
        base.Awake();
        points = 0;
        enemies = GameObject.Find("EnemyManager");
        enemiesManager = enemies.GetComponent<EnemyManager>();
        player = GameObject.Find("Player");
        playerManager = player.GetComponent<Player>();
        trapDoor = GameObject.Find("TrapDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesManager.cantEnemies <= 0&&playerManager.onExit)
        {
            gameOver = true;
            enemiesManager.cantEnemies++;
        }
        if (playerManager.lives<=0)
        {
            playerManager.lives++;
            GoToFinalScene();
        }
        if (gameOver)
        {
            gameOver = false;
            GoToFinalScene();
        }
    }

    void GoToFinalScene()
    {
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, points);
        }
        else if (PlayerPrefs.GetInt(key) < points)
        {
            PlayerPrefs.SetInt(key, points);
        }
        SceneManager.LoadScene("FinalScene");
    }



}