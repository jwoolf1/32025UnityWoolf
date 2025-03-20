using NUnit.Framework.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class coinspawning : MonoBehaviour
{
    public GameObject obj;
    private int spawntimer;
    private Vector3 randomVector;
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (spawntimer == 0) 
        { 
            //SpawnCoin();
            spawntimer = 10;
        }
        else 
        {
            spawntimer--;
        }
    }
    private void SpawnCoin()
    {
        randomVector = new Vector3(transform.position.x /*+ UnityEngine.Random.Range(-500.0f, 500.0f)*/, transform.position.y, transform.position.z /*+ UnityEngine.Random.Range(-500.0f, 500.0f)*/);
        Instantiate(obj, randomVector, transform.rotation);
    }
}
