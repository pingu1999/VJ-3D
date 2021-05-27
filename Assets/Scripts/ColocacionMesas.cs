using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocacionMesas : MonoBehaviour
{
    GameObject myHands; //reference to your hands/the position where you want your object to go
    public GameObject player;
    bool posicionar; //a bool to see if you can or cant posisionate
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    private Vector3 pos;

    void Start()
    {
        posicionar = false;
        myHands = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }

    void Update()
    {
        
        if (posicionar == true && ObjectIwantToPickUp != null) // if you enter thecollider of the objecct
        {
            pos = this.transform.position;
            pos.y = 23.5f;
            pos.x -= 0.25f;
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            ObjectIwantToPickUp.transform.position = pos; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.rotation = rot;
            ObjectIwantToPickUp.transform.parent = null;



        }
        
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {

        if (other.gameObject.tag != "Untagged" && other.gameObject.tag != "Player" && other.gameObject.tag != "Cuchillo" && other.gameObject.tag != "Extintor" && other.gameObject.transform.parent != myHands.transform) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            posicionar = true;  
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        posicionar = false; 

    }
}
