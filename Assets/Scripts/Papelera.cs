using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papelera : MonoBehaviour
{
    private bool eliminar;
    private GameObject Object, myHands;
    public GameObject prefabSarten, Player;
    Vector3 pos;
    void orientacio()
    {
        string dir = PlayerMoviment.Direccio();
        if (dir == "north")
        {
            pos.z += 11f;
            pos.y += 6f;
        }
        else if (dir == "south")
        {
            pos.z -= 11f;
            pos.y += 6f;
        }
        else if (dir == "west")
        {
            pos.x -= 11f;
            pos.y += 6f;
        }
        else if (dir == "est")
        {
            pos.x += 11f;
            pos.y += 6f;
        }
        else if (dir == "north-west")
        {
            pos.x += 8.5f;
            pos.z += 8.5f;
            pos.y += 6f;
        }
        else if (dir == "north-est")
        {
            pos.x -= 8.5f;
            pos.z += 8.5f;
            pos.y += 6f;
        }
        else if (dir == "south-west")
        {
            pos.x += 8.5f;
            pos.z -= 8.5f;
            pos.y += 6f;
        }
        else if (dir == "south-est")
        {
            pos.x -= 8.5f;
            pos.z -= 8.5f;
            pos.y += 6f;
        }
    }
    void Start()
    {
        
        myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }


    void Update()
    {
        if(eliminar)
        {
            if (Object.tag == "Sarten" || Object.tag == "SartenArroz" || Object.tag == "SartenArrozTomate" || Object.tag == "SartenArrozTomateCarne" || Object.tag == "SartenArrozTomateCarneCebolla" || Object.tag == "SartenArrozTomateCarneCebollaGambas" || Object.tag == "SartenArrozTomateCarneCebollaGambasCocinado" || Object.tag == "SartenCarne" || Object.tag == "SartenCarneHecha" || Object.tag == "SartenQuemada")
            {
                Destroy(Object);
                pos = myHands.transform.position; 
                orientacio();
                PlayerMoviment.Recoger();
                Object = Instantiate(prefabSarten) as GameObject;
                Object.GetComponent<Rigidbody>().isKinematic = true;
                Object.transform.parent = myHands.transform;
                Object.transform.position = pos;
                Debug.Log(Object.transform.parent);
            }
            else
            {
                Destroy(Object);
            }
            eliminar = false;
        }
        
    }
    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.tag != "Player" && other.transform.parent == null && other.gameObject.tag != "Extintor")  
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
