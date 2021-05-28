using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrgaComida : MonoBehaviour
{
    private GameObject comidaEntragada;
    bool entrega;
    public AudioSource bien;
    void Start()
    {
        entrega = false;
    }

    void Update()
    {
        if (comidaEntragada != null && entrega)
        {
            bien.Play();
            Destroy(comidaEntragada);
            DisplayReceipts.Entregado();
            Contador.addCont();
            entrega = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == DisplayReceipts.get_nameReceta() || (other.gameObject.tag == "PizzaSimple" && DisplayReceipts.get_nameReceta() == "PizzaQueso") || (other.gameObject.tag == "PizzaQueso" && DisplayReceipts.get_nameReceta() == "PizzaSimple")) && other.gameObject.transform.parent == null)
        {
            comidaEntragada = other.gameObject;
            entrega = true;
        }
    }
}
