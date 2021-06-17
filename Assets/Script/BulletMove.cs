using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMoves();
    }
    void BulletMoves()
    {
        rb.velocity = new Vector2(0, -speed);
    }
    void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "wall2")
        {
            Destroy(gameObject);
        }
    }
}
