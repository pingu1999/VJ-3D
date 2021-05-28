using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject overmenu;
    public GameObject winmenu;
    public GameObject win1; 
    public GameObject lose1;
    static int menu = 0;
    public AudioSource win;
    public AudioSource WinAll;
    public AudioSource lose;

    static bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
     
    }


    static public void setmenu(int i)
    {
        menu = i;
        first = true;
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (menu == 0)
        {
            mainmenu.SetActive(true);
            overmenu.SetActive(false);
            winmenu.SetActive(false);
            win1.SetActive(false);
            lose1.SetActive(false);
        }
        else if (menu == 1)
        {
            mainmenu.SetActive(true);
            overmenu.SetActive(true);
            winmenu.SetActive(false);
            win1.SetActive(false);
            lose1.SetActive(false);
        }
        else if (menu == 2)
        {
            if (first)
            {
                WinAll.Play();
                first = false;
            }
            mainmenu.SetActive(false);
            overmenu.SetActive(false);
            winmenu.SetActive(true);
            win1.SetActive(false);
            lose1.SetActive(false);
        }
        else if (menu == 3)
        {
            if (first)
            {
                win.Play();
                first = false;
            }
            mainmenu.SetActive(false);
            overmenu.SetActive(false);
            winmenu.SetActive(false);
            win1.SetActive(true);
            lose1.SetActive(false);
        }
        else if (menu == 4)
        {
            if (first)
            {
                lose.Play();
                first = false;
            }
            mainmenu.SetActive(false);
            overmenu.SetActive(false);
            winmenu.SetActive(false);
            win1.SetActive(false);
            lose1.SetActive(true);
        }
        else
        {
            
        }
    }
}
