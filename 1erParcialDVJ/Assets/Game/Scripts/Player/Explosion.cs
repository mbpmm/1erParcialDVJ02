using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
