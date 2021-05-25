using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResaltarObjetivo : MonoBehaviour
{

    List<GameObject> Mesas = new List<GameObject>();
    void Start()
    {
        DisplayReceipts.start();
    }

  
    void Update()
    {
        for (int i = 0;  i < Mesas.Count; ++i)
        {
            Mesas[i].GetComponent<Outline>().enabled = true;
        }
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {

        if (other.gameObject.tag == "Untagged" && !Mesas.Contains(other.gameObject)) 
        {
            Mesas.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Untagged" && Mesas.Contains(other.gameObject))
        {
            //Debug.Log(Mesas[Mesas.IndexOf(other.gameObject)].GetComponent<Outline>());
            Mesas[Mesas.IndexOf(other.gameObject)].GetComponent<Outline>().enabled = false;
            Mesas.Remove(other.gameObject);
        }
    }
}
