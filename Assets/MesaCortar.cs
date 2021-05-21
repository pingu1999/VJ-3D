using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaCortar : MonoBehaviour
{
    GameObject myHands; //reference to your hands/the position where you want your object to go
    GameObject Hand;
    bool posicionar, ready; //a bool to see if you can or cant posisionate
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    private Vector3 pos;
    public GameObject cuchillo;
    public GameObject player;
    GameObject sustituto;


    //prefabs
    [SerializeField] private GameObject prefabCarneCortada;

    void Start()
    {
        posicionar = false;
        ready = true;
        myHands = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
        Hand = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").gameObject;
}


    public IEnumerator accion(int seconds)
    {
        PlayerMoviment.Recoger();
        yield return new WaitForSeconds((float)seconds);  // espera 3 segons


        pos = myHands.transform.position;
        orientacio();
        if (ObjectIwantToPickUp.gameObject.tag == "Carne")
        {
            sustituto = Instantiate(prefabCarneCortada) as GameObject;
        }
        
        else if (ObjectIwantToPickUp.gameObject.tag != "Carne")
        {
            sustituto = Instantiate(prefabCarneCortada) as GameObject;
        }


        //set de las variables de playerpick
        PlayerPick.sethasItem(true);
        PlayerPick.sethObjectIwantToPickUp(sustituto);

        //colocar el nuevo objeto en la mano
        Destroy(ObjectIwantToPickUp);
        sustituto.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        sustituto.transform.position = pos; // sets the position of the object to your hand position
        sustituto.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands



        //dejar el cuchillo
        pos = this.transform.position;
        pos.y += 17.6f;
        cuchillo.GetComponent<Rigidbody>().isKinematic = true;
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        cuchillo.transform.position = pos;
        cuchillo.transform.Rotate(0f, 0f, +98.0f);
        cuchillo.transform.parent = null;

        Debug.Log("3 segons despres");
        ready = true;
        ObjectIwantToPickUp = null;


        PlayerMoviment.setblock(false);
        
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
        
        if (ready == true && posicionar == true && ObjectIwantToPickUp != null) // if you enter thecollider of the objecct
        {
            //Debug.Log("cojo cuchilo y dejo lo que tengo en la mano");
            ready = false;
            pos = this.transform.position;
            pos.y = 23.5f;
            pos.x -= 0.25f;
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false;   //makes the rigidbody not be acted upon by forces
            ObjectIwantToPickUp.transform.position = pos; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.rotation = rot;
            ObjectIwantToPickUp.transform.parent = null;
            Debug.Log("carne sin padre");

            //recoger el cuchillo
            //PlayerMoviment.Recoger();
            //orientacio();
            pos = Hand.transform.position;
            pos.x = -0.0131000001f;
            pos.y = 0.000300000014f;
            cuchillo.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
              // sets the position of the object to your hand position
            cuchillo.transform.parent = Hand.transform; //makes the object become a child of the parent so that it moves with the hands
            Debug.Log(cuchillo.transform.parent);
            cuchillo.transform.position = pos;
            Debug.Log(cuchillo.transform.position);
            cuchillo.transform.Rotate(0f, 0f, -98.0f);
            Debug.Log(cuchillo.transform.rotation);






            //Llamo a funcion para bloquear al player y llamo a cortar que tarda 3 segundos.
            PlayerMoviment.setblock(true);
            StartCoroutine(accion(3));

        }
       
        
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if ((other.gameObject.transform.parent != myHands.transform) && other.gameObject.tag != "Player" && other.gameObject.tag != "Cuchillo" && (other.gameObject.tag == "Carne" /*|| other.gameObject.tag == "Lechuga" || other.gameObject.tag == "Tomate" || other.gameObject.tag == "Queso" || other.gameObject.tag == "Pizza" || other.gameObject.tag == "Pan" || other.gameObject.tag == "Cebolla" || other.gameObject.tag == "Gambas" || other.gameObject.tag == "Arroz"*/)) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            //Debug.Log("dentro2");
            posicionar = true;
            ObjectIwantToPickUp = other.gameObject; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        posicionar = false; 

    }
}
