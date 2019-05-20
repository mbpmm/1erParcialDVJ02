using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemies;
    private EnemyManager enemiesManager;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.Find("EnemyManager");
        enemiesManager = enemies.GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            enemiesManager.cantEnemies--;
            Destroy(gameObject);
        }
    }
}
