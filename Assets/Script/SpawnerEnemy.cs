using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletD;
    public GameObject spWeapon;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject thunder;
    public static bool bossDead = false;
    private float typebullet;
    public BoxCollider2D box;
    private bool check = true, checkbl = true, checkboss = false, checkthunder=true;
    bool spawON = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
       
        if(checkboss==false && spawON == true)
        {
            if(check)
            {            
                StartCoroutine(Spawner());
            }
            if(checkbl)
            {
                StartCoroutine(SpawnerBullet());
            }
            if(checkthunder)
            {
                StartCoroutine(SpawnerThunder());
            }
        }
        if (CountPoint.point == GamePlay_Crt.maxpoint)
        {
            spawON = false;
            if(checkboss==false)
            {
                SpawnerBoss();
                checkboss = true;
            }        
        }
        if (spawON == false && GamePlay_Crt.bossdead == true)
        {
            spawON = true;
            checkboss = false;                 
        }

    }
   IEnumerator SpawnerThunder()
    {
        checkthunder = false;
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector2 v2 = transform.position;
        v2.x = Random.Range(minX, maxX);
        v2.y = 0f;
        Instantiate(thunder, v2, Quaternion.identity);
        CameraShake.shakeDuration = 2f;
        yield return new WaitForSeconds(Random.Range(5f, 10f));      
        checkthunder = true;
    }
    IEnumerator Spawner()
    {
        check = false;       
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector2 v2 = transform.position;
        v2.x = Random.Range(minX, maxX);
        Instantiate(enemy, v2, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        check = true;
    }
    IEnumerator SpawnerBullet()
    {
        checkbl = false;
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector2 v2 = transform.position;
        v2.x = Random.Range(minX, maxX);
        typebullet = Random.Range(1, 6);
        switch(typebullet)
        {
            case 1:
                Instantiate(bulletA, v2, Quaternion.identity);
                break;
            case 2:
                Instantiate(bulletB, v2, Quaternion.identity);
                break;
            case 3:
                Instantiate(bulletC, v2, Quaternion.identity);
                break;
            case 4:
                Instantiate(bulletD, v2, Quaternion.identity);
                break;
            case 5:
                Instantiate(spWeapon, v2, Quaternion.identity);
                break;
        }      
        yield return new WaitForSeconds(Random.Range(5f, 10f));     
        checkbl = true;
    }
   void SpawnerBoss()
    {
        if(GamePlay_Crt.bossnumber==1)
        {
            Instantiate(boss1, transform.position, Quaternion.identity);        
            checkboss = true;
        }
        if(GamePlay_Crt.bossnumber == 2)
        {
            Vector3 v3 = new Vector3(transform.position.x, transform.position.y, -1);
            Instantiate(boss2, v3, Quaternion.identity);
            checkboss = true;
        }      
        
    }
}
