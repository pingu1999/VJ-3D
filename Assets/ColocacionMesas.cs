using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocacionMesas : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool posicionar; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    //bool hasItem; // a bool to see if you have an item in your hand
    // Start is called before the first frame update
    private Vector3 pos;

    void Start()
    {
        posicionar = false;    //setting both to false
        //hasItem = false;
    }

    void Update()
    {
        //bool aux = true;
        if (posicionar == true) // if you enter thecollider of the objecct
        {
            // aux = false;
            pos = this.transform.position;
            pos.y = 23.5f;
            pos.x -= 0.25f;
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            ObjectIwantToPickUp.transform.position = pos; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.rotation = rot;



        }
        /*if (Input.GetKeyDown(KeyCode.E) && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
        {

            PlayerMoviment.Recoger();
            Debug.Log("soltar");
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

            ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
            hasItem = false;
        }*/
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {

        if (other.gameObject.tag != "Untagged" && other.gameObject.transform.parent != myHands.transform) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            posicionar = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        posicionar = false; //when you leave the collider set the canpickup bool to false

    }
}
