using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop_Ct : MonoBehaviour
{
    public GameObject pl2;
    public GameObject pl3;
    public GameObject pl4;
    public static int money;
    public Text cost_txt,money_txt;
    public Button bt_buy;
    public Button bt_right, bt_left;
    int count = 1, cost;
    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetInt("Money", 0);
        Money();
        bt_right.onClick.AddListener(OnclickRight);
        bt_left.onClick.AddListener(OnclickLeft);
        bt_buy.onClick.AddListener(BuyPlane);
    }

    // Update is called once per frame
    void Update()
    {
        CostPlane();
        money_txt.text = money.ToString() + "$";
    }
    void OnclickRight()
    {
        if (count <= 1)
        {
            count = 3;         
        } 
        else
            count--;
        switch (count)
        {
            case 1:
                pl3.SetActive(false);
                pl2.SetActive(true);
                break;
            case 2:
                pl4.SetActive(false);
                pl3.SetActive(true);
                break;
            case 3:
                pl2.SetActive(false);
                pl4.SetActive(true);
                break;
        }
    }
    void OnclickLeft()
    {     
        if(count>=3 || count <0)
        {
            count = 1;
        }
        else
        count++;

       switch(count)
        {
            case 1:
                pl4.SetActive(false);
                pl2.SetActive(true);                 
                break;
            case 2:
                pl2.SetActive(false);
                pl3.SetActive(true);
                break;
            case 3:
                pl3.SetActive(false);
                pl4.SetActive(true);
                break;
        }
       
    }
    void CostPlane()
    {
        if(pl2.active == true)
        {
            cost = 500;
            cost_txt.text = cost.ToString()+ "$";
        }
        if (pl3.active == true)
        {
            cost = 600;
            cost_txt.text = cost.ToString() + "$";
        }
        if (pl4.active == true)
        {
            cost = 700;
            cost_txt.text = cost.ToString() + "$";
        }
    }
    void Money()
    {
        if (PlayerPrefs.HasKey("Money"))
            money = PlayerPrefs.GetInt("Money");
        else
            money = 0;
    }
    void BuyPlane()
    {
        if(money >=cost)
        {
            money = money - cost;
            PlayerPrefs.SetInt("Money", money);
        }     
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
