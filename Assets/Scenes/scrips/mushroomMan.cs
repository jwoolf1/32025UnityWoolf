using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

public class mushroomMan : MonoBehaviour
{
    public GameObject me;
    public GameObject target;
    public float xAngle, yAngle, zAngle;
    private bool touchingplayer;
    void Start()
    {
     
    }
    void Update()
    {
        me.transform.LookAt(target.transform);

        xAngle = me.transform.localRotation.eulerAngles.x;
        yAngle = me.transform.localRotation.eulerAngles.y;
        zAngle = me.transform.localRotation.eulerAngles.z;

        if (Vector3.Distance(target.transform.position, me.transform.position) < 1.5f)
        {
            touchingplayer = true;
            
        }
        else
        {
            touchingplayer = false;
        }

    }
    void FixedUpdate()
    {
        me.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);

        if (!touchingplayer)
        {
            transform.position += transform.right / 10; 
            transform.position += transform.forward / 10;
        }

        Player player = GetComponent<Player>();
        if (Vector3.Distance(target.transform.position, me.transform.position) < 2f)
        {
            player.playerHurt();
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (other.gameObject.name == "Player")
        {
            touchingplayer = true;
        }
        else
        {
            touchingplayer = false;
        }
    }*/
}
