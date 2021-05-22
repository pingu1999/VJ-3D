using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirIngredientes : MonoBehaviour
{
    bool lechuga, tomate, pan, pizza, queso, paella, carne, novalid;
    GameObject Object, myHands, Player;
    private Vector3 pos;
    GameObject _platoposcombinacion;
    [SerializeField] private GameObject prefabSarten, prefabEnsaladaTomate, prefabHamburguesaLechugaTomate, prefabHamburguesaSimple, prefabPaella, prefabPizzaQueso;
    [SerializeField] private GameObject prefabPizzaSimple, prefabBasePizza, prefabBasePizzaTomate, prefabBasePizzaTomateQueso, prefabPlatoLechuga, prefabPan, prefabPanLechuga, prefabPanLechugaTomate;


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
        else if (pizza && gameObject.tag == "Plato")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            pizza = false;
            _platoposcombinacion = Instantiate(prefabBasePizza) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (tomate && gameObject.tag == "PlatoBasePizza")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            tomate = false;
            _platoposcombinacion = Instantiate(prefabBasePizzaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (queso && gameObject.tag == "PlatoBasePizzaTomate")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            queso = false;
            _platoposcombinacion = Instantiate(prefabBasePizzaTomateQueso) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (pan && gameObject.tag == "Plato")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            pan = false;
            _platoposcombinacion = Instantiate(prefabPan) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (lechuga && gameObject.tag == "PlatoPan")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            lechuga = false;
            _platoposcombinacion = Instantiate(prefabPanLechuga) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (tomate && gameObject.tag == "PlatoPanLechuga")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            tomate = false;
            _platoposcombinacion = Instantiate(prefabPanLechugaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }
        else if (carne && gameObject.tag == "PlatoPanLechugaTomate")
        {
            Vector3 pos1 = gameObject.transform.position;
            pos = myHands.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            carne = false;
            _platoposcombinacion = Instantiate(prefabHamburguesaLechugaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos1;


            GameObject sarten = Instantiate(prefabSarten) as GameObject;
            orientacio();
            sarten.GetComponent<Rigidbody>().isKinematic = true;

            PlayerMoviment.Recoger();
            sarten.transform.position = pos; // sets the position of the object to your hand position

            sarten.transform.parent = myHands.transform; 
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(sarten);
        }
        else if (carne && gameObject.tag == "PlatoPan")
        {
            Vector3 pos1 = gameObject.transform.position;
            pos = myHands.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            carne = false;
            _platoposcombinacion = Instantiate(prefabHamburguesaSimple) as GameObject;
            _platoposcombinacion.transform.position = pos1;


            GameObject sarten = Instantiate(prefabSarten) as GameObject;
            orientacio();
            sarten.GetComponent<Rigidbody>().isKinematic = true;

            PlayerMoviment.Recoger();
            sarten.transform.position = pos; // sets the position of the object to your hand position

            sarten.transform.parent = myHands.transform;
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(sarten);
        }
        else if (paella && gameObject.tag == "Plato")
        {
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);


            paella = false;
            _platoposcombinacion = Instantiate(prefabPaella) as GameObject;
            _platoposcombinacion.transform.position = pos;
        }


        else if (novalid)
        {

            PlayerMoviment.Recoger();
            pos = myHands.transform.position;
            Debug.Log(pos);
            orientacio();
            Debug.Log(pos);
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
      else if (other.gameObject.tag == "BaseDePizzaCortada" && other.transform.parent == null)
       {
            pizza = true;
            Object = other.gameObject;
       }
      else if (other.gameObject.tag == "QuesoCortado" && other.transform.parent == null)
       {
            queso = true;
            Object = other.gameObject;
       }
      else if (other.gameObject.tag == "PanCortado" && other.transform.parent == null)
       {
            pan = true;
            Object = other.gameObject;
       }
      else if (other.gameObject.tag == "SartenArrozTomateCarneCebollaGambasCocinado" && other.transform.parent == null)
       {
            paella = true;
            Object = other.gameObject;
       }




      else if (other.gameObject.tag != "Untagged"  && other.gameObject.tag != "Player" && other.transform.parent == null && other.gameObject.tag != "Plato" && other.gameObject.tag != "Sarten" && !PlayerPick.gethasItem())
        {
            novalid = true;
            Object = other.gameObject;
        }
    }
}
