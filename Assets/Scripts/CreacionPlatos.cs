using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionPlatos : MonoBehaviour
{
    bool contact, plat;
    private GameObject Player;
    [SerializeField]    private GameObject prefabPlato;
    private GameObject _plato;
    GameObject myHands;
    Vector3 pos;



    void Start()
    {
        contact = false;
        plat = true;
       
    }

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

    void Update()
    {
        if (contact && Player != null && plat && Input.GetKeyUp(KeyCode.E))
        {
            myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
            _plato = Instantiate(prefabPlato) as GameObject;
            
            PlayerMoviment.Recoger();
            pos = myHands.transform.position;

            orientacio();
            _plato.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            _plato.transform.position = pos; // sets the position of the object to your hand position
            _plato.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(_plato);
            plat = false;
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        
        if (other.gameObject.tag == "Player" && !PlayerPick.gethasItem())
        {
            contact = true;
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        contact = false;
        plat = true;
    }
}
