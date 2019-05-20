using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives;
    public bool onExit;
    private Vector3 initPos;
    

    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            lives--;
            transform.position = initPos;
        }
        if (other.gameObject.tag == "Enemy")
        {
            lives--;
            transform.position = initPos;
        }
        if (other.gameObject.tag == "TrapDoor")
        {
            onExit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TrapDoor")
        {
            onExit = false;
        }
    }
}
