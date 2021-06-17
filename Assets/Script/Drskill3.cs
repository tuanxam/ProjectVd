using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drskill3 : MonoBehaviour
{
    public static Vector2 v2;
    public Rigidbody2D rb;
    public float speed;
    public GameObject no;
    void Start()
    {

    }
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        rb.velocity = v2 * speed;
    }
    void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "wall2" || cl.gameObject.tag == "Pl1")
        {
            Instantiate(no, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
