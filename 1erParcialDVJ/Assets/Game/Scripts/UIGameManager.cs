using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public Text lives;

    private GameObject player;
    private Player playMgr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playMgr = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + playMgr.lives;
    }
}
