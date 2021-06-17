using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpSkill : MonoBehaviour
{
    public static Vector2 v2;
    private Vector3 v3;
    public GameObject wall;
    private float  maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));     
        maxY = bound.y;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        transform.position = v2;
        transform.localScale = new Vector3(1,(wall.transform.position.y+v2.y)/2, 1);
        v3 = transform.localScale;
        if(v3.y >maxY)
        {
            v3.y = maxY;
        }
        transform.localScale = v3;
    }
}
