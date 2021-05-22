using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinacionesSarten : MonoBehaviour
{

    bool arroz, tomate, carne, cebolla, gambas, pescado, novalid;
    GameObject Object, myHands, Player;
    private Vector3 pos;
    GameObject _platoposcombinacion;
    [SerializeField] private GameObject prefabSarten, prefabSartenArroz, prefabSartenArrozTomate, prefabSartenArrozTomateCarne, prefabSartenArrozTomateCarneCebolla, prefabSartenArrozTomateCarneCebollaGambas;
    [SerializeField] private GameObject prefabSartenArrozTomateCarneCebollaGambasCocinado, prefabSartenCarne, prefabSartenCarneHecha;


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
        else Debug.Log("Tonto");
    }
    void Start()
    {
        Player = GameObject.Find("Player");
        myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }
    void CombinacionConSartenes()
    {
        if (arroz && gameObject.tag == "Sarten")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            arroz = false;
            _platoposcombinacion = Instantiate(prefabSartenArroz) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (carne && gameObject.tag == "Sarten")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            carne = false;
            _platoposcombinacion = Instantiate(prefabSartenCarne) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }


        else if (novalid)
        {

            PlayerMoviment.Recoger();
            pos = myHands.transform.position;
            orientacio();
            Object.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            Object.transform.position = pos; // sets the position of the object to your hand position
            Object.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(Object);
            novalid = false;
        }
    }

    void Update()
    {
        CombinacionConSartenes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArrozCortado" && other.transform.parent == null)
        {
            arroz = true;
            Object = other.gameObject;
        }

        else if (other.gameObject.tag == "CarneCortada" && other.transform.parent == null)
        {
            carne = true;
            Object = other.gameObject;

        }




        else if (other.gameObject.tag != "Untagged" && other.gameObject.tag != "Player" && other.transform.parent == null && other.gameObject.tag != "Plato" && other.gameObject.tag != "Sarten")
        {
            novalid = true;
            Object = other.gameObject;
        }
    }
    /*
    GameObject myHands; //reference to your hands/the position where you want your object to go
    bool fusionarcarne_sarten; //a bool to see if you fusionate them
    GameObject Object; // the gameobject onwhich you collided with
    private Vector3 pos;
    public GameObject player;
    [SerializeField]
    private GameObject prefabSartenCarne;
    private GameObject _sartencarne;


    void Start()
    {
        myHands = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }

    void Update()
    {
        if (fusionarcarne_sarten)
        {
            fusionarcarne_sarten = false;
            pos = gameObject.transform.position;
            //new WaitForSeconds(0.5f);
            Destroy(Object);
            Destroy(gameObject);
            //Object.transform.parent = null;
            _sartencarne = Instantiate(prefabSartenCarne) as GameObject;
            _sartencarne.transform.position = pos;
            


        }
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "CarneCortada" && other.transform.parent == null)
        {
            Debug.Log("Combinacion");
            fusionarcarne_sarten = true;
            Object = other.gameObject;
          
        } 
            
    }
   */
}
