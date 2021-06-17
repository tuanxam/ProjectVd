using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{
    public static Vector2 v2;
    private Vector3 v3;
    public float speed;
    public Rigidbody2D rb;
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
        v3 = new Vector3(v2.x, v2.y, -1);
        transform.position =v3;
        transform.localScale = new Vector3(1, ( 4.5f-v2.y )/2, 1);
    }
}
