using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{  
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;
    public GameObject yellowbullet;
    bool canshoot = true;
    public GameObject no;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoves();
        EnemyFire();
    }
    void EnemyMoves()
    {
        float y=0;
        y = (y-0.2f) * speed;
        rb.velocity = new Vector2(0, y );
    }
    void EnemyFire()
    {      
            if (canshoot)
            {
                StartCoroutine(Shoot());
            }
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        float y = transform.position.y - 1f;
        Vector2 v2 = new Vector2(transform.position.x, y);
        Instantiate(yellowbullet, v2, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        canshoot = true;
    }
    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "wall2"|| cl.gameObject.tag == "redbullet")
        {
           if(cl.gameObject.tag=="redbullet")
            {

                CountPoint.point++;
            }          
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        GameObject ex = Instantiate(no, transform.position, Quaternion.identity);
        Destroy(ex, 1f);
    }
}
