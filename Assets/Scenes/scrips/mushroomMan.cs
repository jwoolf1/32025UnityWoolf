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
    public int attackcooldown;
    public Text healthtext;
    public int playerhealth;
    void Start()
    {
        attackcooldown = 5;
        playerhealth = 100;
    }
    void Update()
    {
        if (gameObject != null)
        {
            me.transform.LookAt(target.transform);

            xAngle = me.transform.localRotation.eulerAngles.x;
            yAngle = me.transform.localRotation.eulerAngles.y;
            zAngle = me.transform.localRotation.eulerAngles.z;

            if (Vector3.Distance(target.transform.position, me.transform.position) < 1.5f && Vector3.Distance(target.transform.position, me.transform.position) > 5f)
            {
                touchingplayer = true;
            }
            if (!(Vector3.Distance(target.transform.position, me.transform.position) < 1.5f && Vector3.Distance(target.transform.position, me.transform.position) > 5f))
            {
                touchingplayer = false;
            }
        }

    }
    void FixedUpdate()
    {
        if (gameObject != null)
        {
            me.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);

            if (!touchingplayer)
            {
                transform.position += transform.right / 10;
                transform.position += transform.forward / 10;
            }
            attackcooldown--;
            Player player = target.GetComponent<Player>();
            if (Vector3.Distance(target.transform.position, me.transform.position) < 1f * (int)me.transform.localScale.x)
            {
                //Player.PlayerHurt();
                if (attackcooldown <= 0)
                {
                    playerhealth -= 1 * (int)me.transform.localScale.x;
                    healthtext.text = playerhealth.ToString();
                    attackcooldown = 5;
                }
            }
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
