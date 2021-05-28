using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUPWIN : MonoBehaviour
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

    public void Next()
    {
        Timer.setcount(0);
        if (escene == "1_nivell")
        {
            Debug.Log("2 nivell");
            SceneManager.LoadScene(2);
        }
        else if (escene == "2_nivell")
        {
            SceneManager.LoadScene(3);
        }
        else if (escene == "3_nivell")
        {
            SceneManager.LoadScene(4);
        }
        else if (escene == "4_nivell")
        {
            SceneManager.LoadScene(5);
        }
        else if (escene == "5_nivell")
        {
            SelectorMenu.setmenu(2);
            SceneManager.LoadScene(0);
        }
    }

    void Start()
    {
        //Debug.Log(star1.GetComponent<Image>());
        int count = Timer.get_count();
        if (count >= 7)
        {
            GetComponentsInChildren<Image>()[0].color = new Color(1, 1, 1, 1);
            GetComponentsInChildren<Image>()[1].color = new Color(1, 1, 1, 1);
            GetComponentsInChildren<Image>()[2].color = new Color(1, 1, 1, 1);
        }
        else if (count >= 6)
        {
            GetComponentsInChildren<Image>()[0].color = new Color(1, 1, 1, 1);
            GetComponentsInChildren<Image>()[1].color = new Color(1, 1, 1, 1);
            GetComponentsInChildren<Image>()[2].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
        }
        else if (count >= 5)
        {
            GetComponentsInChildren<Image>()[0].color = new Color(1, 1, 1, 1);
            GetComponentsInChildren<Image>()[1].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
            GetComponentsInChildren<Image>()[2].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
        }
        else
        {
            GetComponentsInChildren<Image>()[0].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
            GetComponentsInChildren<Image>()[1].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
            GetComponentsInChildren<Image>()[2].color = new Color(0.3962264f, 0.3962264f, 0.3962264f, 1);
        }
    }

    void Update()
    {
        
    }
}
