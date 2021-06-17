using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public static Vector2 v2;
    public Rigidbody2D rb;
    public GameObject danA;
    public GameObject danB;
    public GameObject danC;
    public GameObject danD;
    public GameObject no;
    public GameObject gun;
    public GameObject gunleft;
    public GameObject gunright;
    public GameObject hp;
    bool dr_fire = false;
    public float speed;

    float x, y, type, hpoint = 1, minX, maxX, minY, maxY;
    bool canshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bound.x + 0.5f;
        maxX = bound.x - 0.5f;
        minY = -bound.y / 2;
        maxY = bound.y - 3f;
    }

    // Update is called once per frame
    void Update()
    {
        DragonFire.v2 = gun.transform.position;
        BossMv();
        Fire();
    }
    void BossMv()
    {
        //x = Random.Range(minX, maxX) * speed;
         y = Random.Range(minY, maxY) * speed;
        rb.velocity = new Vector2(v2.x,y);      
        Bound();


    }
    void Fire()
    {
        if (canshoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        type = Random.Range(1, 4);
        if (hpoint <= 0.5 && dr_fire == false)
        {
            Instantiate(danD, gun.transform.position, Quaternion.identity);
            CameraShake.shakeDuration = 1;
            dr_fire = true;
        }
        switch (type)
        {
            case 1:
                Instantiate(danA, gunleft.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(danB, gunright.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(danC, gunleft.transform.position, Quaternion.identity);
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
        if (cl.gameObject.tag == "redbullet")
        {
            hpoint = hpoint - 0.01f;
            hp.transform.localScale = new Vector2(hpoint, 1);
            if (hpoint < 0.01f)
            {
                GamePlay_Crt.bossdead = true;
                CountPoint.point += 20;
                Destroy(gameObject);
            }
        }

    }
}
