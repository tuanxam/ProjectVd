using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay_Crt : MonoBehaviour
{
    public static GamePlay_Crt Gp_crt;
    public GameObject pausepanel;
    public GameObject gameoverpn;
    public GameObject plane;
    public GameObject cameraMain;
    public static bool bossdead=false;
    public static int bossnumber = 1, maxpoint = 5;
    private bool death=false;
    // Start is called before the first frame update
    private void Update()
    {

        death = Move.dead;
        if (death==true)
        {
          
           
            if (CountPoint.point > CountPoint.hs)
            {
                PlayerPrefs.SetInt("Hiscore", CountPoint.point);
            }         
            GameoverPanel();
          
        }else
        {
            gameoverpn.SetActive(false);
        }
        loadScene2();
    }
    public void PauseButton()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void PlayAgButton()
    {
        Move.dead = false;
        CountPoint.point = 0;
        maxpoint = 10;
        bossnumber = 1;
        // Application.LoadLevel("GamePlay");    
        SceneManager.LoadScene(1);
        
    }
    public void MenuButton()
    {
        Move.dead = false;
        Shop_Ct.money += CountPoint.point * 1000;
        PlayerPrefs.SetInt("Money", Shop_Ct.money);
        Debug.Log(Shop_Ct.money);
        //Application.LoadLevel("Menu");
        SceneManager.LoadScene(0);
    }
    public void GameoverPanel()
    {
        gameoverpn.SetActive(true);     
    }
    public void loadScene2()
    {     
      if(bossdead==true)
        {
            DontDestroyOnLoad(plane);
            CameraShake.shakeDuration = 0;
            SceneManager.LoadScene(2);
            maxpoint += 15;
            bossnumber = 2;           
            bossdead = false;
        }
    }
}

