using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    private GameObject manager;
    private GameManager gameManager;
    private int wallPoints;

    private void Start()
    {
        wallPoints = 10;
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            gameManager.points += wallPoints;
            Destroy(gameObject);
        }
    }
}
