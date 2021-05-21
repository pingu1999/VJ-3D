using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papelera : MonoBehaviour
{
    private bool eliminar;
    private GameObject Object;


    void Start()
    {
       
    }


    void Update()
    {
        if(eliminar)
        {
            Destroy(Object);
            eliminar = false;
        }
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag != "Player" && other.transform.parent == null) 
        {
            eliminar = true;  
            Object = other.gameObject; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        eliminar = false; 

    }
}
