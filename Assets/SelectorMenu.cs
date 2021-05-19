using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject overmenu;
    public GameObject winmenu;
    static int menu = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (menu == 0)
        {
            mainmenu.SetActive(true);
        }
        else if (menu == 1)
        {
            Debug.Log("segona vegada");
            overmenu.SetActive(true);
        }
        else if (menu == 2)
        {
            Debug.Log("segona vegada");
            winmenu.SetActive(true);
        }
     
    }

    static public void setmenu(int i)
    {
        menu = i;
    } 

    // Update is called once per frame
    void Update()
    {
    }
}
