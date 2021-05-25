using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayReceipts : MonoBehaviour
{
    public GameObject Receipt1;
    public GameObject Receipt2;
    public GameObject Receipt3;

    public Sprite EnsaladaSimple;
    public Sprite EnsaladaCompleta;
    public Sprite PizzaSimple;
    public Sprite PizzaCompleta;
    public Sprite HamburguesaSimple;
    public Sprite HamburguesaCompleta;
    public Sprite Paella;

    static private float tmp1, tmp2, tmp3;
    static private int i, j, k;
    Slider Barra1, Barra2, Barra3;
    private List<string> Receipts;
    static private string nameReceta;
    static private bool entregado; 

    void Awake()
    {
        Barra1 = GetComponentsInChildren<Slider>()[0];
        Barra2 = GetComponentsInChildren<Slider>()[1];
        Barra3 = GetComponentsInChildren<Slider>()[2];
    }
    static public void start()
    {
        ReceiptController.change_scene();
        i = 0;
        j = 1;
        k = 2;
        tmp1 = 0;
        tmp2 = 0;
        tmp3 = 0;
        entregado = false;
    }

    static public void Entregado()
    {
        entregado = true;
    }

    static public string get_nameReceta()
    {
        return nameReceta;
    } 

    void Update()
    {
        if (tmp1 > 40 || entregado)
        {
            i = j;
            tmp1 = tmp2;
            j = k;
            tmp2 = tmp3;
            ++k;
            tmp3 = 0;
            entregado = false;

        }

        tmp1 += 1 * Time.deltaTime;
        tmp2 += 1 * Time.deltaTime;
        tmp3 += 1 * Time.deltaTime;

        Receipts = ReceiptController.get_recipes();
        nameReceta = Receipts[i];
        Barra1.value = tmp1;
        Barra2.value = tmp2;
        Barra3.value = tmp3;

        if (Receipts != null && Receipts[i] == "PlatoLechuga")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[i] == "EnsaladaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "PizzaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[i] == "PizzaQueso")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaLechugaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "Paella")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }


        if (Receipts != null && Receipts[j] == "PlatoLechuga")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[j] == "EnsaladaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "PizzaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[j] == "PizzaQueso")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaLechugaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "Paella")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }



        if (Receipts != null && Receipts[k] == "PlatoLechuga")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[k] == "EnsaladaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "PizzaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[k] == "PizzaQueso")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaLechugaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "Paella")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }

    }


   
}
