using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Mv : MonoBehaviour
{
    public static Item_Mv item;
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        item = GetComponent<Item_Mv>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Moveleft()
    {
        rb.velocity = new Vector2(4, 0) * -speed;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
    }
    IEnumerator Moveright()
    {
        rb.velocity = new Vector2(4, 0) * speed;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
    }
    public void Mv_left()
    {
        StartCoroutine(Moveleft());
    }
    public void Mv_right()
    {
        StartCoroutine(Moveright());
    }   
}
