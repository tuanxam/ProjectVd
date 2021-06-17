using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject danA;
    public GameObject danB;
    public GameObject danC;
    public GameObject no;
    public GameObject gun;
    public GameObject hp;
    public float speed;
    float x, y, type, hpoint = 1, minX, maxX, minY, maxY;
    bool canshoot=true;
    void Start()
    {
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bound.x+0.3f;
        maxX = bound.x-0.3f;
        minY = -bound.y/2;
        maxY = bound.y-1f;
    }
    void Update()
    {
        BossMv();
        Fire();
    }
    void BossMv()
    {       
        x = Random.Range(minX, maxX) * speed;
        y = Random.Range(minY, maxY) * speed;
        rb.velocity = new Vector2(x, y);
        Bound();
    }
    void Fire()
    {
        if(canshoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        type = Random.Range(1, 4);
   
        switch (type)
        {
            case 1:
                Instantiate(danA,gun.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(danB,gun.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(danC,gun.transform.position, Quaternion.identity);
                break;
        }
        yield return new WaitForSeconds(1f);
        canshoot = true;
    }
    void Bound()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        else if (temp.x < minX)
        {
            temp.x = minX;
        }
        if (temp.y > maxY)
        {
            temp.y = maxY;
        }
        else if (temp.y < minY)
        {
            temp.y = minY;
        }
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D cl)
    {
        if(cl.gameObject.tag=="redbullet")
        {
            hpoint = hpoint- 0.05f;         
            hp.transform.localScale = new Vector2(hpoint, 1);
            if(hpoint < 0.05f)
            {
                GamePlay_Crt.bossdead = true;
                CountPoint.point += 10;
                Destroy(gameObject);           
            }
        }
        
    }
}
