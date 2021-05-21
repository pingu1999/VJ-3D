using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResaltarObjetivo : MonoBehaviour
{

    private bool resaltar;
    GameObject Mesas;


    void Start()
    {
        resaltar = false;
    }

  
    void Update()
    {
        if (resaltar)
        {
            Mesas.GetComponent<Outline>().enabled = true;
        }
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        //Debug.Log(other.gameObject.tag);
        //Debug.Log(resaltar); //true
        if (other.gameObject.tag == "Untagged" && !resaltar) 
        {
            //Debug.Log("entra");
            resaltar = true;  //set the pick up bool to true
            Mesas = other.gameObject;
           // Debug.Log(Mesas);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Untagged" && resaltar)
        {
            resaltar = false; 
            if (Mesas != null)
            {
                Mesas.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
