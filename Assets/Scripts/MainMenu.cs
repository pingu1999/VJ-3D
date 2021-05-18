using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public OverMenu overmenu;
    public void PlayGame()
    {
  
        this.gameObject.SetActive(false);
        Debug.Log(this.gameObject.name);
        overmenu.activate();
        
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

  
}
