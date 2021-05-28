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
    public AudioSource song;

    static bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        song.mute = false;
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
            song.mute = false;
            mainmenu.SetActive(true);
            overmenu.SetActive(false);
            winmenu.SetActive(false);
            win1.SetActive(false);
            lose1.SetActive(false);
        }
        else if (menu == 1)
        {
            song.mute = false;
            mainmenu.SetActive(false);
            overmenu.SetActive(false);
            winmenu.SetActive(false);
            win1.SetActive(false);
            lose1.SetActive(false);
        }
        else if (menu == 2)
        {
            song.mute = true;
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
            song.mute = true;
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
            song.mute = true;
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
            song.mute = true;
        }
    }
}
