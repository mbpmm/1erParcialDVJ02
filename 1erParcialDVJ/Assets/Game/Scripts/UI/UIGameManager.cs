using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public Text lives;
    public Text points;
    public Text enemiesLeft;

    private GameObject manager;
    private GameManager gameManager;
    private GameObject enemies;
    private EnemyManager enemiesManager;
    private GameObject player;
    private Player playMgr;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        enemies = GameObject.Find("EnemyManager");
        enemiesManager = enemies.GetComponent<EnemyManager>();
        player = GameObject.Find("Player");
        playMgr = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + playMgr.lives;
        points.text = "Points: " + gameManager.points;
        enemiesLeft.text = "Enemies Left: " + enemiesManager.cantEnemies;
    }
}
