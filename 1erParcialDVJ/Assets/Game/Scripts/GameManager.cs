using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public float points;
    public float enemiesAlive;

    private bool gameOver;
    private GameObject enemies;
    private EnemyManager enemiesManager;
    private GameObject player;
    private Player playerManager;
    private GameObject trapDoor;

    public override void Awake()
    {
        base.Awake();
        enemies = GameObject.Find("EnemyManager");
        enemiesManager = enemies.GetComponent<EnemyManager>();
        player = GameObject.Find("Player");
        playerManager = player.GetComponent<Player>();
        trapDoor = GameObject.Find("TrapDoor");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Cant "+enemiesManager.cantEnemies);
        Debug.Log(playerManager.onExit);
        if (enemiesManager.cantEnemies <= 0&&playerManager.onExit)
        {
            gameOver = true;
            enemiesManager.cantEnemies++;
        }
        if (gameOver)
        {
            gameOver = false;
            GoToFinalScene();
        }
    }

    void GoToFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }



}