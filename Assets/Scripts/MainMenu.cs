using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Canvas overmenu;
    public void PlayGame()
    {
        Timer.setcount(0);
        SceneManager.LoadScene(1);

    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

  
}
