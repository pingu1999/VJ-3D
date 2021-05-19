using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    Slider Barra;
    public Text valorString;
    float max = 10;
    public float act;
    
    
    void Awake ()
    {
        Barra = GetComponent<Slider>();
        //valorString = GetComponent<Text>();
    }

    void Start ()
    {
        //act = Timer.getcount();
    }

    void Update ()
    {
        ActualizarValorBarra(max, act);
    }
    void ActualizarValorBarra(float valorMax, float valorAct)
    {
        float porcentaje;
        porcentaje = valorAct / valorMax;
        Barra.value = porcentaje;
        valorString.text = porcentaje*100 + "%";
        
    }
}
