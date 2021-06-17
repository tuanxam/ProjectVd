using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCrt : MonoBehaviour
{
    // Start is called before the first frame update
  public void PlayButton()
    {
        Application.LoadLevel("GamePlay");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ShopButton()
    {
        SceneManager.LoadScene(3);
    }
}
