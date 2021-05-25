using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocinar : MonoBehaviour
{
    GameObject producte, cocinado;
    static string estat;
    private float tiempo;
    private bool product;
    string input;
    [SerializeField] private GameObject prefabCarneCocinada;
    [SerializeField] private GameObject prefabPaella;
    [SerializeField] private GameObject Player;
    Vector3 pos;
    void Start()
    {
        estat = "apagat";
        tiempo = 0;
        product = true;

    }
    public static string get_estat()
    {
        return estat;
    }

    void Update()
    {
        //Debug.Log(producte != null);
        //Debug.Log(estat == "apagat");
        //Debug.Log(product);

        if (producte != null && estat == "apagat" && product)
        {
            Debug.Log("Encendido");
            Destroy(producte);
            estat = "cocinando";
        }
        else if (producte != null && estat == "cocinando" && product)
        {
            Debug.Log("cocinando");
            if (tiempo > 3.0f)
            {
                estat = "cocinado";
            }
        }
        else if (producte != null && estat == "cocinado" && product)
        {
            Debug.Log("cocinado");
            if (tiempo > 7f)
            {
                estat = "quemado";
            }
        }
        else if (producte != null && estat == "quemado" && product)
        {
            Debug.Log("Quemado");

        }

        tiempo += 1 * Time.deltaTime;
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
            Debug.Log("Entra");
            producte = other.gameObject;
            product = true;
            input = other.name;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !PlayerPick.gethasItem() && Input.GetKeyUp(KeyCode.E))
        {
            if (input == "SartenArrozTomateCarneCebollaGambas")
            {
                cocinado = Instantiate(prefabPaella) as GameObject;
            }

            else
            {
                cocinado = Instantiate(prefabCarneCocinada) as GameObject;
            }

            PlayerMoviment.Recoger();
            pos = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject.transform.position;

            orientacio();
            cocinado.GetComponent<Rigidbody>().isKinematic = true;
            cocinado.transform.position = pos;
            cocinado.transform.parent = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject.transform;
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(cocinado);
        }
    }
}
