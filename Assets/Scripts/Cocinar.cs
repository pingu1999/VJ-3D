using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocinar : MonoBehaviour
{
    GameObject producte, myHands;
    static string estat;
    private float tiempo, tmp;
    private bool product, extraer, apagar;
    string input;
    [SerializeField] private GameObject prefabCarneCocinada;
    [SerializeField] private GameObject prefabCarne;

    [SerializeField] private GameObject prefabPaella;
    [SerializeField] private GameObject prefabSartenArrozTomateCarneCebollaGambas;

    [SerializeField] private GameObject prefabSartenQuemada;

    [SerializeField] private GameObject Player;
    Vector3 pos;
    void Start()
    {
        estat = "apagat";
        tiempo = 0;
        product = false;
        extraer = false;
        myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;

    }
    public static string get_estat()
    {
        return estat;
    }

    void Update()
    {
        //Debug.Log(producte != null);
        //Debug.Log(estat == "cocinando");
        //Debug.Log(product);
        if (producte != null && estat == "apagat" && product)
        {
            estat = "cocinando";
            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(true);
        }
        if (estat == "cocinando" && product && tiempo > 5.0f)
        {
            
            Vector3 posicion = producte.transform.position;
            Quaternion rotation = producte.transform.rotation;
            Destroy(producte);
            if (input == "SartenCarne")
            {
                producte = Instantiate(prefabCarneCocinada) as GameObject;
            }
            else if (input == "SartenArrozTomateCarneCebollaGambas")
            {
                producte = Instantiate(prefabPaella) as GameObject;
            }
            
            producte.GetComponent<Rigidbody>().isKinematic = true;   
            producte.transform.position = posicion; 
            producte.transform.rotation = rotation;
            producte.transform.parent = null;
            estat = "cocinado";
        }
        if (estat == "cocinado" && product && tiempo > 7.5f)
        {
            Vector3 posicion = producte.transform.position;
            Quaternion rotation = producte.transform.rotation;
            Destroy(producte);

            producte = Instantiate(prefabSartenQuemada);

            producte.GetComponent<Rigidbody>().isKinematic = true;
            producte.transform.position = posicion;
            producte.transform.rotation = rotation;
            producte.transform.parent = null;


            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(true);
            estat = "quemado";
        }
        if (estat == "quemado" && product && apagar && Extentor.get_encendido())
        {
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(false);
        }

        if (extraer && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyUp(KeyCode.E)))
        {
            
            extraer = false;
            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(false);

            product = false;
            estat = "apagat";
            tiempo = 0;
            extraer = false;
            

        }

        //contador de segundos
        if (estat != "apagat")
        {
        tiempo += 1 * Time.deltaTime;
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent == null && (other.gameObject.tag == "SartenArrozTomateCarneCebollaGambas" || other.gameObject.tag == "SartenCarne"))
        {
            producte = other.gameObject;
            product = true;
            input = other.name;

            //colocacion en el centro del fuego
            pos = this.transform.position;
            pos.y = 23.5f;
            pos.x -= 0.25f;
            pos.z += 2f;
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            other.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            other.transform.position = pos; // sets the position of the object to your hand position
            other.transform.rotation = rot;
            other.transform.parent = null;
        }


        if (other.gameObject.tag == "Player" && !PlayerPick.gethasItem())
        {
            extraer = true;
        }

        if (other.gameObject.tag == "Extintor")
        {
            apagar = true;
        }

    }

        private void OnTriggerExit(Collider other)
        {
            extraer = false;
            apagar = false;
        }
}