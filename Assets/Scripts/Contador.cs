using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{

    Text contador;
    static int Cont;

    void Awake()
    {
        contador = GetComponent<Text>();
    }

    void Start()
    {
        Cont = 0;
    }

    static public void addCont()
    {
        ++Cont;
        Timer.setcount(Cont);
    }

    void Update()
    {
        contador.text = Cont.ToString() + "/7" ;
    }
}
