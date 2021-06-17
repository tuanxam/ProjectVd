using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPoint : MonoBehaviour
{
    public static int point;

    public Text txtPoint;
    public Text txtGameOver;
    public static int hs;
    // Start is called before the first frame update
    void Start()
    {    
        if(PlayerPrefs.HasKey("Hiscore"))
        {
            hs = PlayerPrefs.GetInt("Hiscore");
        }
        else
        {
            hs = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtPoint.text = point.ToString();
        txtGameOver.text = hs.ToString();
    }
  
}
