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

    static bool acabar;


    //prefabs
    [SerializeField] private GameObject prefabCarneCortada;
    [SerializeField] private GameObject prefabTomateCortado;
    [SerializeField] private GameObject prefabLechugaCortada;
    [SerializeField] private GameObject prefabQuesoCortado;
    [SerializeField] private GameObject prefabPizzaCortada;
    [SerializeField] private GameObject prefabPanCortado;
    [SerializeField] private GameObject prefabCebollaCortada;
    [SerializeField] private GameObject prefabGambasCortadas; 
    [SerializeField] private GameObject prefabArrozCortado;

    void Start()
    {
        posicionar = false;
        ready = true;
        acabar = false;
        myHands = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
        Hand = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").Find("mixamorig:Spine1").Find("mixamorig:Spine2").Find("mixamorig:RightShoulder").Find("mixamorig:RightArm").Find("mixamorig:RightForeArm").Find("mixamorig:RightHand").gameObject;
    }

    static public void change_acabar()
    {
        acabar = !acabar;
    }

    void setsustituto()
    {
    
        if (ObjectIwantToPickUp.gameObject.tag == "Carne")
        {
            sustituto = Instantiate(prefabCarneCortada) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Tomate")
        {
          
            sustituto = Instantiate(prefabTomateCortado) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Lechuga")
        {
            sustituto = Instantiate(prefabLechugaCortada) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Queso")
        {
            sustituto = Instantiate(prefabQuesoCortado) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Pizza")
        {
            sustituto = Instantiate(prefabPizzaCortada) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Pan")
        {
            sustituto = Instantiate(prefabPanCortado) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Cebolla")
        {
            sustituto = Instantiate(prefabCebollaCortada) as GameObject;
        }

        else if (ObjectIwantToPickUp.gameObject.tag == "Gambas")
        {
            sustituto = Instantiate(prefabGambasCortadas) as GameObject;
        }
        else if (ObjectIwantToPickUp.gameObject.tag == "Arroz")
        {
            sustituto = Instantiate(prefabArrozCortado) as GameObject;
        }

    }


    public IEnumerator accion(int seconds)
    {
        PlayerMoviment.Recoger();
        if (!acabar)
        {
            yield return new WaitForSeconds((float)seconds);  // espera 3 segons
        }


        pos = myHands.transform.position;
        orientacio();
        setsustituto();
        


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
        cuchillo.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        cuchillo.transform.parent = null;

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
        //Debug.Log(cuchillo.transform.rotation);
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

            cuchillo.GetComponent<Rigidbody>().isKinematic = true;  
            cuchillo.transform.parent = Hand.transform; 
          
            pos = new Vector3(0f, 0f, 0f);
            cuchillo.transform.position = pos;
            
            cuchillo.transform.Rotate(0f, 164f, -98.0f);
           
            pos = Hand.transform.position;
            pos.x += -0.6f;
            pos.y += 0.00120000006f;
            pos.z += 0.00529999984f;
            cuchillo.transform.position = pos;
           

            PlayerMoviment.setblock(true);
            StartCoroutine(accion(3));

        }
       
        
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if ((other.gameObject.transform.parent != myHands.transform) && other.gameObject.tag != "Player" && other.gameObject.tag != "Cuchillo" && (other.gameObject.tag == "Carne" || other.gameObject.tag == "Lechuga" || other.gameObject.tag == "Tomate" || other.gameObject.tag == "Queso" || other.gameObject.tag == "Pizza" || other.gameObject.tag == "Pan" || other.gameObject.tag == "Cebolla" || other.gameObject.tag == "Gambas" || other.gameObject.tag == "Arroz")) //on the object you want to pick up set the tag to be anything, in this case "object"
        { 
            posicionar = true;
            ObjectIwantToPickUp = other.gameObject; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        posicionar = false; 

    }
}
