using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int coins;
    public GameObject Capsule;
    public GameObject FreeLook;
    private float horizontalInput;
    private float verticalInput;
    private bool jumpKeyPressed;
    private Rigidbody rb;
    //public Transform Camera;
    //public Transform PlayerOBJ;
    public float xAngle, yAngle, zAngle;
    void Start()
    {
        //float xAngle = Capsule.transform.localRotation.eulerAngles.x;
        //float yAngle = FreeLook.transform.localRotation.eulerAngles.y;
        //float zAngle = Capsule.transform.localRotation.eulerAngles.z;
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }
        xAngle = Capsule.transform.localRotation.eulerAngles.x;
        yAngle = FreeLook.transform.localRotation.eulerAngles.y;
        zAngle = Capsule.transform.localRotation.eulerAngles.z;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().linearVelocity = new Vector3(horizontalInput*25, GetComponent<Rigidbody>().linearVelocity.y, verticalInput*25);
        transform.position += transform.right * horizontalInput / 5;
        transform.position += transform.forward * verticalInput / 5;

        if (jumpKeyPressed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 15, ForceMode.VelocityChange); 
            jumpKeyPressed = false;
        }

        //Capsule.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //print(yAngle);
        Capsule.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        //transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
    }
    public void coinCollected() 
    {
        coins++;
        print(coins);
    }
}
