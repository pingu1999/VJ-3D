using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverMenu : MonoBehaviour
{
    /*static public void activate()
    {
        this.gameObject.SetActive(true);
        Debug.Log(this.gameObject.name);
       
    }*/
    public void QuitGame()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void GoMenu()
    {

        SceneManager.LoadScene(0);
    }
}
