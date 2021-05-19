using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    string tiempoText;
    public float  tiempo = 60.0f;
    static int count = 0;
    Text timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = GetComponent<Text>();
    }

    static public int getcount ()
    {
        return count;
    }

    public void Update()
    {
        if (count > 10)
        {
            //next level o Wininng;
            if (SceneManager.GetSceneByName("5_nivell") != null)
            {
                SelectorMenu.setmenu(2);
                SceneManager.LoadScene(0);
            }
        }
        else if (tiempo > 0)
        {

            tiempo -= 1 * Time.deltaTime;
            tiempoText = "" + tiempo.ToString("f0");
        }
        else if (tiempo <= 0) {
            new WaitForSeconds(3);
            SelectorMenu.setmenu(1);
            SceneManager.LoadScene(0);

        }
        timer.text = tiempoText;
    }
}
