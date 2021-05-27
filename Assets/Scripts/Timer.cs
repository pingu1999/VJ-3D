using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    string tiempoText;
    public float  tiempo;
    static int count = 0;
    Text timer;
    public GameObject clock;
    Color valor;
    string signo = "+";
    // Start is called before the first frame update
    void Awake()
    {
        timer = GetComponent<Text>();
    }
    void Start()
    {
        valor = new Color(0, 0.01f, 0.01f, 0);
    }

    static public void setcount (int Cont)
    {
        count = Cont;
    }

    public void Update()
    {
        if (tiempo <= 15)
        {
            if (signo == "-")
            {
                clock.GetComponentsInChildren<Image>()[0].color -= valor;
                valor.g -= 15 / 255;
                valor.b -= 15 / 255;
                if (clock.GetComponentsInChildren<Image>()[0].color.g <= 0 + 0.01f)
                {
                    signo = "+";
                }
            }
            else
            {
                clock.GetComponentsInChildren<Image>()[0].color += valor;
                valor.g += 15 / 255;
                valor.b += 15 / 255;
                if (clock.GetComponentsInChildren<Image>()[0].color.g >= 1 - 0.01f)
                {
                    signo = "-";
                }
            }
        } 
        if (count >= 7)
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
