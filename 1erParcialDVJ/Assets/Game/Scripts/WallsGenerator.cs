﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGenerator : MonoBehaviour
{
    public GameObject wall;

    private int posMin;
    private int posMax;
    private int cantWalls;
    private int posX;
    private int posZ;
    // Start is called before the first frame update
    void Start()
    {
        posMin = -9;
        posMax = 9;
        cantWalls = 30;
        for (int i = 0; i < cantWalls; i++)
        {
            while (posX%2==0&&posZ%2==0)
            {
                posX = Random.Range(posMin, posMax);
                posZ = Random.Range(posMin, posMax);
                if (posX==posMin&&posZ==posMin)
                {
                    posX = Random.Range(posMin, posMax);
                    posZ = Random.Range(posMin, posMax);
                }
            }
            Vector3 pos = new Vector3(posX, 0, posZ);
            GameObject auxWalls;
            auxWalls = Instantiate(wall, pos, Quaternion.identity);
            posX = 0;
            posZ = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
