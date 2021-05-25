using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hornear : MonoBehaviour
{
    GameObject producte, cocinado, myHands;
    static string estat;
    private float tiempo;
    private bool product, extraer;
    string input;
    [SerializeField] private GameObject prefabPizzaSimple;
    [SerializeField] private GameObject prefabPlatoBasePizzaTomate;

    [SerializeField] private GameObject prefabPizzaCompleta;
    [SerializeField] private GameObject prefabPlatoBasePizzaTomateQueso;

    [SerializeField] private GameObject prefabSartenQuemada;

    [SerializeField] private GameObject Player;
    Vector3 pos;
    void Start()
    {
        estat = "apagat";
        tiempo = 0;
        product = true;
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
            Destroy(producte);
            estat = "cocinando";
        }
        if (estat == "cocinando" && product && tiempo > 5.0f)
        {
            estat = "cocinado";
        }
        if (estat == "cocinado" && product && tiempo > 7.5f)
        {
            estat = "quemado";

        }
        if (estat == "quemado" && product)
        {

        }

        if (extraer && Input.GetKeyDown(KeyCode.E))
        {
            extraer = false;
            if (input == "PlatoBasePizzaTomate")
            {
                if (estat == "cocinado")
                {
                    cocinado = Instantiate(prefabPizzaSimple) as GameObject;
                }

                else if (estat == "quemado")
                {
                    cocinado = Instantiate(prefabSartenQuemada) as GameObject;
                }
                else
                {
                    cocinado = Instantiate(prefabPlatoBasePizzaTomate) as GameObject;
                }
            }

            else
            {
                if (estat == "cocinado")
                {
                    cocinado = Instantiate(prefabPizzaCompleta) as GameObject;
                }
                else if (estat == "quemado")
                {
                    cocinado = Instantiate(prefabPlatoBasePizzaTomateQueso) as GameObject;
                }
                else
                {
                    cocinado = Instantiate(prefabPlatoBasePizzaTomate) as GameObject;
                }
            }

            product = false;

            PlayerMoviment.Recoger();
            pos = myHands.transform.position;

            orientacio();
            cocinado.GetComponent<Rigidbody>().isKinematic = true;
            cocinado.transform.position = pos;
            Debug.Log(cocinado.transform.position);
            cocinado.transform.parent = myHands.transform;
            Debug.Log(cocinado.transform.parent);
            PlayerPick.sethasItem(true);
            PlayerPick.sethObjectIwantToPickUp(cocinado);
            
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
        if (other.gameObject.transform.parent == null && (other.gameObject.tag == "PlatoBasePizzaTomate" || other.gameObject.tag == "PlatoBasePizzaTomateQueso"))
        {
            producte = other.gameObject;
            product = true;
            input = other.name;
        }


        Debug.Log(Input.GetKeyDown(KeyCode.E));
        if (other.gameObject.tag == "Player" && !PlayerPick.gethasItem())
        {
            Debug.Log("Entra");
            extraer = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        extraer = false;
    }
}
