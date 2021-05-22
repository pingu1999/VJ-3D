using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirIngredientes : MonoBehaviour
{
    bool lechuga, tomate, pan, pizza, queso, paella, carne;
    GameObject Object, myHands, Player;
    GameObject _platoposcombinacion;
    [SerializeField] private GameObject prefabSarten, prefabEnsaladaTomate, prefabHamburguesaLechugaTomate, prefabHamburguesaSimple, prefabPaella, prefabPizzaQueso;
    [SerializeField] private GameObject prefabPizzaSimple, prefabBasePizza, prefabBasePizzaTomate, prefabBasePizzaTomateQueso, prefabPlatoLechuga, prefabPan, prefabPanLechuga, prefabPanLechugaTomate;


    void orientacio(Vector3 pos)
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
        Player = GameObject.Find("Player");
        myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }
    void CombinacionConPlatos()
    {
        if (lechuga && gameObject.tag == "Plato")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            lechuga = false;
            _platoposcombinacion = Instantiate(prefabPlatoLechuga) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (tomate && gameObject.tag == "PlatoLechuga")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            tomate = false;
            _platoposcombinacion = Instantiate(prefabEnsaladaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (carne && gameObject.tag == "PlatoPanLechugaTomate")
        {
            Vector3 pos = gameObject.transform.position;
            Vector3 pos1 = Object.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            tomate = false;
            _platoposcombinacion = Instantiate(prefabHamburguesaLechugaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;


            GameObject sarten = Instantiate(prefabSarten) as GameObject;
            orientacio(pos1);
            sarten.GetComponent<Rigidbody>().isKinematic = true;

            PlayerMoviment.Recoger();
            sarten.transform.position = pos1; // sets the position of the object to your hand position

            sarten.transform.parent = myHands.transform; 
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(sarten);
        }

    }

    void Update()
    {
        CombinacionConPlatos();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "LechugaCortada" && other.transform.parent == null)
      {
            lechuga = true;
            Object = other.gameObject;
      }

      else if (other.gameObject.tag == "TomateCortado" && other.transform.parent == null)
       {
            tomate = true;
            Object = other.gameObject;

       }
      else if (other.gameObject.tag == "SartenCarneHecha" && other.transform.parent == null)
       { 
            carne = true;
            Object = other.gameObject;

       }
    }
}
