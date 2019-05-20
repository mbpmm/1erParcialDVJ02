using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemies;
    private EnemyManager enemiesManager;
    private GameObject manager;
    private GameManager gameManager;
    private int enemyPoints;
    // Start is called before the first frame update
    void Start()
    {
        enemyPoints = 200;
        enemies = GameObject.Find("EnemyManager");
        enemiesManager = enemies.GetComponent<EnemyManager>();
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            gameManager.points += enemyPoints;
            enemiesManager.cantEnemies--;
            Destroy(gameObject);
        }
    }
}
