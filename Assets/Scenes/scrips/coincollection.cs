using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class coincollection : MonoBehaviour
{
    private void Start()
    {

    }
    private void Update()
    {
 
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (other.gameObject.name == "Player")
        {
            player.coinCollected();
            gameObject.SetActive(false);
            print("Coin Collected");
        }
    }
}