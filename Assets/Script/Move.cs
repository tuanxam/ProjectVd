using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed,typebullet;
    public GameObject bulletDf;
    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletD;
    public GameObject bulletE;
    public GameObject bulletSP;
    public GameObject PowerBar;
    public GameObject Hpbar;
    public GameObject gun;
    public GameObject gunleft;
    public GameObject gunright;
    public GameObject no;
    float hp = 10;
    float pow = 10;
    public static bool dead=false;
    private bool canshoot = true;
    void Start()
    {    
       
    }
    // Update is called once per frame
    void Update()
    {
        SpSkill.v2 = gun.transform.position;
        PlanMove();
        PlanRotale();
        PlanFire();
    }
    void PlanMove()
    {     
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(x, y);
    }
    void PlanRotale()
    {
        //  Vector3 mousepos = tagets.transform.position;
        //    mousepos = Camera.main.WorldToScreenPoint(mousepos);
        //    Vector2 dr = new Vector2(mousepos.x - transform.position.x,
        //                            mousepos.y - transform.position.y);
        //    transform.up = dr;
        // transform.Rotate(new Vector3(0,0, Input.GetAxis("Mouse Y")*speed));
        // float angle = Mathf.() * Mathf.Rad2Deg;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dr = (mousepos - (Vector2)transform.position).normalized;
        transform.up = dr;
    }
    void PlanFire()
    {
        if (Input.GetMouseButton(0))
        {
            if (canshoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        //float y = transform.position.y;
        //Vector2 v2 = new Vector2(transform.position.x, y);
       switch(typebullet)
        {
            case 1:
                Instantiate(bulletA, gun.transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(bulletB, gun.transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(bulletC, gun.transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(bulletD, gun.transform.position, transform.rotation);
                break;
            case 5:
                Instantiate(bulletE, gunleft.transform.position, transform.rotation);
                Instantiate(bulletE, gunright.transform.position, transform.rotation);
                break;
            default:
                Instantiate(bulletDf, gun.transform.position, transform.rotation);
                //if(pow == 10)
                //{
                //    Instantiate(bulletSP, gun.transform.position, transform.rotation);
                //    yield return new WaitForSeconds(10f);
                //    pow = 0;
                //}
                break;
        }
        
        yield return new WaitForSeconds(0.2f);
        canshoot = true;
    }
    private void OnTriggerEnter2D(Collider2D cl)
    {
        
        if (cl.gameObject.tag == "enemy")
        {             
            dead = true;
            Destroy(gameObject);                   
        }   
        if (cl.gameObject.tag == "yellowbullet")
        {
            hp = (hp - 1);
            Hpbar.transform.localScale = new Vector2(hp/10,1);
            if (hp < 0.1)
            {              
                dead = true;             
                Destroy(gameObject);
            }
        }
        if(cl.gameObject.tag == "thunder" || cl.gameObject.tag == "Drfire")
        {
            hp = hp - 0.2f;
            Hpbar.transform.localScale = new Vector2(hp / 10, 1);
            if (hp < 0.1)
            {
                dead = true;
                Destroy(gameObject);
            }
        }
        if (cl.gameObject.tag == "bulletA")
        {
            typebullet = 1;
        }
        if (cl.gameObject.tag =="bulletB")
        {
            typebullet = 2;
        }
        if (cl.gameObject.tag == "bulletC")
        {
            typebullet = 3;
        }
        if (cl.gameObject.tag == "bulletD")
        {
            typebullet = 4;
        }
        if(cl.gameObject.tag=="spweapon1")
        {
            typebullet = 5;
            gunleft.SetActive(true);
            gunright.SetActive(true);
        }

    }
}
