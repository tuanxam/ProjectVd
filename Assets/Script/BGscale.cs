using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscale : MonoBehaviour
{
    public float speed;
    private Renderer rend;
    void Start()
    {
        ScaleBG();
    }
    void Update()
    {
        ScrollBG();
    }
    void ScaleBG()
    {
        float w_height = Camera.main.orthographicSize * 2;
        float w_width = w_height * Screen.width / Screen.height;
        transform.localScale = new Vector3(w_width, w_height, 0f);
    }
    void ScrollBG()
    {
        rend = GetComponent<Renderer>();
        float offset = Time.time * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0,offset));
    }
}
