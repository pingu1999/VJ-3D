using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinacionesSarten : MonoBehaviour
{

    bool carneHecha, arroz, tomate, carne, cebolla, gambas, pescado, novalid;
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
        else if (tomate && gameObject.tag == "SartenArroz")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            tomate = false;
            _platoposcombinacion = Instantiate(prefabSartenArrozTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (carne && gameObject.tag == "SartenArrozTomate")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            carne = false;
            _platoposcombinacion = Instantiate(prefabSartenArrozTomateCarne) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (cebolla && gameObject.tag == "SartenArrozTomateCarne")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            cebolla = false;
            _platoposcombinacion = Instantiate(prefabSartenArrozTomateCarneCebolla) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (gambas && gameObject.tag == "SartenArrozTomateCarneCebolla")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            cebolla = false;
            _platoposcombinacion = Instantiate(prefabSartenArrozTomateCarneCebollaGambas) as GameObject;
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

        else if (other.gameObject.tag == "TomateCortado" && other.transform.parent == null)
        {
            tomate = true;
            Object = other.gameObject;

        }

        else if (other.gameObject.tag == "CebollaCortada" && other.transform.parent == null)
        {
            cebolla = true;
            Object = other.gameObject;

        }

        else if (other.gameObject.tag == "GambasCortadas" && other.transform.parent == null)
        {
            gambas = true;
            Object = other.gameObject;

        }

        else if (other.gameObject.tag != "Untagged" && other.gameObject.tag != "Player" && other.transform.parent == null && other.gameObject.tag != "Plato" && other.gameObject.tag != "Sarten" && transform.parent == null)
        {
            Debug.Log("novaid");
            novalid = true;
            Object = other.gameObject;
        }
    }
}
