using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coins;
    public int health;
    public int damagecooldown;
    public GameObject Capsule;
    public GameObject FreeLook;
    public GameObject ground;
    public GameObject Bullet;
    private float horizontalInput;
    private float verticalInput;
    private bool jumpKeyPressed;
    private bool isGrounded;
    private Rigidbody rb;
    public Text coinstext;
    public Text healthtext;
    public TerrainCollider terrainCollider;
    //public Transform Camera;
    //public Transform PlayerOBJ;
    public float xAngle, yAngle, zAngle;
    private Vector3 bulletvector;
    void Start()
    {
        //float xAngle = Capsule.transform.localRotation.eulerAngles.x;
        //float yAngle = FreeLook.transform.localRotation.eulerAngles.y;
        //float zAngle = Capsule.transform.localRotation.eulerAngles.z;
        Rigidbody rb = GetComponent<Rigidbody>();
        health = 100;
        damagecooldown = 5;
        terrainCollider.isTrigger = true;
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

        //Vector3 bulletvector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Vector3 bulletrotation = new Vector3(xAngle,yAngle,zAngle);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bulletvector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(Bullet,bulletvector,transform.rotation);
        }


    }
    public void FixedUpdate()
    {
        //GetComponent<Rigidbody>().linearVelocity = new Vector3(horizontalInput*25, GetComponent<Rigidbody>().linearVelocity.y, verticalInput*25);
        transform.position += transform.right * horizontalInput / 5;
        transform.position += transform.forward * verticalInput / 5;
        if (jumpKeyPressed && !isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange); 
            jumpKeyPressed = false;
        }

        damagecooldown--;

        //Capsule.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //print(yAngle);
        Capsule.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        //transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
    }
    public void coinCollected() 
    {
        coins++;
        coinstext.text = coins.ToString();
    }
    public void PlayerHurt()
    {
        if (damagecooldown <= 0)
        {
            health--;
            healthtext.text = health.ToString();
            damagecooldown = 5;
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        _ = other.GetComponent<TerrainCollider>();
        if (other.gameObject.name == "Terrain")
        {
            isGrounded = true;
            print(isGrounded);
        }
    }*/
}
