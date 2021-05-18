using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void activate()
    {
        this.gameObject.SetActive(true);
        Debug.Log(this.gameObject.name);
        SceneManager.LoadScene(1);
    }
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
