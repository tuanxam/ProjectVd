﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBl : MonoBehaviour
{
    // Use this for initialization
    public Rigidbody2D rb;
    public float speed;
    public GameObject no;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        rb.velocity = transform.up * -speed;
    }
    void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "wall2" || cl.gameObject.tag=="Pl1")
        {
            Instantiate(no, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
