using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; 
    private Vector3 pos;

    void Start()
    {
        myHands = transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
        canpickup = false;    //setting both to false
        hasItem = false;
    }
    void orientacio ()
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
    // Update is called once per frame
    void Update()
    {

        if (canpickup == true && Input.GetKeyDown(KeyCode.E) && hasItem == false && ObjectIwantToPickUp != null)  // can be e or any key
        {
            PlayerMoviment.Recoger();
            Debug.Log("recoger");
            pos = myHands.transform.position;
            orientacio();
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            ObjectIwantToPickUp.transform.position = pos; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
            hasItem = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItem == true ) // if you have an item and get the key to remove the object, again can be any key
        {
            
            PlayerMoviment.Recoger();
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

            ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
            Vector3 pos = ObjectIwantToPickUp.transform.position;
            pos.y += 0.5f;
            ObjectIwantToPickUp.transform.position = pos;
            hasItem = false;
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        
         if (other.gameObject.tag != "Untagged" && !hasItem && other.gameObject.tag != "Cuchillo" && other.gameObject.tag != "Player") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
           // Debug.Log(other.name + "trigger");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false

    }
}
