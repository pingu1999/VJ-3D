using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUPLOSE : MonoBehaviour
{
    static public string escene;
    public void GoMenu()
    {
        Debug.Log("Menu");
        SelectorMenu.setmenu(0);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Timer.setcount(0);
        Debug.Log("restart");
        if (escene == "1_nivell")
        {
            Debug.Log("1 nivell");
            SceneManager.LoadScene(1);
        }
        else if (escene == "2_nivell")
        {
            SceneManager.LoadScene(2);
        }
        else if (escene == "3_nivell")
        {
            SceneManager.LoadScene(3);
        }
        else if (escene == "4_nivell")
        {
            SceneManager.LoadScene(4);
        }
        else if (escene == "5_nivell")
        {
            SceneManager.LoadScene(5);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
