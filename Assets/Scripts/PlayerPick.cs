using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand
    // Start is called before the first frame update
    private Vector3 pos;

    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
    }
    
    void orientacio ()
    {
        string dir = PlayerMoviment.Direccio();
        if (dir == "north")
        {
            pos.z += 10f;
            pos.y += 6f;
        }
        else if (dir == "south")
        {
            pos.z -= 10f;
            pos.y += 6f;
        }
        else if (dir == "west")
        {
            pos.x -= 10f;
            pos.y += 6f;
        }
        else if (dir == "est")
        {
            pos.x += 10f;
            pos.y += 6f;
        }
        else if (dir == "north-west")
        {
            pos.x += 8f;
            pos.z += 8f;
            pos.y += 6f;
        }
        else if (dir == "north-est")
        {
            pos.x -= 8f;
            pos.z += 8f;
            pos.y += 6f;
        }
        else if (dir == "south-west")
        {
            pos.x += 8f;
            pos.z -= 8f;
            pos.y += 6f;
        }
        else if (dir == "south-est")
        {
            pos.x -= 8f; 
            pos.z -= 8f;
            pos.y += 6f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool aux = true;
        if (canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKeyDown(KeyCode.E) && hasItem == false)  // can be e or any key
            {
                PlayerMoviment.Recoger();
                aux = false;
                pos = myHands.transform.position;
                orientacio();
                ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                ObjectIwantToPickUp.transform.position = pos; // sets the position of the object to your hand position
                ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && hasItem == true && aux) // if you have an item and get the key to remove the object, again can be any key
        {

            PlayerMoviment.Recoger();
            Debug.Log("soltar");
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

            ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
            hasItem = false;
        }
        aux = true;
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        
        if (other.gameObject.tag == "Objects") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false

    }































    /*public GameObject item; 
    //public GameObject tempParent; 
    public Transform guide; 

    bool carrying;
    public float range = 12;

    private Animator anim;
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (carrying == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && (guide.transform.position - transform.position).sqrMagnitude < range / range)
            {
                anim.SetBool("recoger", !anim.GetBool("recoger"));
                pickup();
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
                carrying = false;
            }
        }
    }
    void pickup()
    {
        Vector3 pos = guide.transform.position;
        pos.z = pos.z + 10.0f;
        pos.y = pos.y + 15f;
        Debug.Log("Pick");
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log(item.transform.name);
        item.transform.position = pos;
        item.transform.rotation = guide.transform.rotation;
        //item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        Debug.Log("Drop!");
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }*/
}
