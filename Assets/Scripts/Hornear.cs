using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hornear : MonoBehaviour
{
    GameObject producte, cocinado, myHands;
    static string estat;
    private float tiempo, tmp;
    private bool product, extraer, apagar;
    string input;
    static bool godmode, acabar;
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
        product = false;
        extraer = false;
        myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
        godmode = false;
        acabar = false;
    }

    static public void change_acabar()
    {
        acabar = !acabar;
    }

    static public void change_godmode()
    {
        godmode = !godmode;
    }
    public static string get_estat()
    {
        return estat;
    }

    void Update()
    {
        
        if (!acabar && producte != null && estat == "apagat" && product)
        {
            Destroy(producte);
            estat = "cocinando";
            transform.Find("ParticulasHornoCocinado").gameObject.SetActive(true);
        }
        if (acabar || (estat == "cocinando" && product && tiempo > 5.0f))
        {
            if (producte != null)
            {
                Destroy(producte);
                transform.Find("ParticulasHornoCocinado").gameObject.SetActive(true);
            }
            estat = "cocinado";
        }
        if (estat == "cocinado" && product && tiempo > 7.5f && !godmode)
        {
            transform.Find("ParticulasHornoCocinado").gameObject.SetActive(false);
            transform.Find("ParticulasHornoQuemado").gameObject.SetActive(true);
            estat = "quemado";
        }
        if (estat == "quemado" && product && apagar && Extentor.get_encendido())
        {
            transform.Find("ParticulasHornoQuemado").gameObject.SetActive(false);
        }

        if (product && extraer && Input.GetKeyDown(KeyCode.E))
        {
            extraer = false;
            transform.Find("ParticulasHornoCocinado").gameObject.SetActive(false);
            transform.Find("ParticulasHornoQuemado").gameObject.SetActive(false);
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
                product = false;
                estat = "apagat";
                tiempo = 0;
                extraer = false;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                cocinado.GetComponent<Rigidbody>().isKinematic = true;
                cocinado.transform.parent = myHands.transform;
                cocinado.transform.position = pos;
                
                
                PlayerPick.sethObjectIwantToPickUp(cocinado);
            }

            else if (input == "PlatoBasePizzaTomateQueso")
            {
                if (estat == "cocinado")
                {
                    cocinado = Instantiate(prefabPizzaCompleta) as GameObject;
                }
                else if (estat == "quemado")
                {
                    cocinado = Instantiate(prefabSartenQuemada) as GameObject;
                }
                else
                {
                    cocinado = Instantiate(prefabPlatoBasePizzaTomateQueso) as GameObject;
                }
                product = false;
                estat = "apagat";
                tiempo = 0;
                extraer = false;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                cocinado.GetComponent<Rigidbody>().isKinematic = true;
                cocinado.transform.parent = myHands.transform;
                cocinado.transform.position = pos;
                
               
                PlayerPick.sethObjectIwantToPickUp(cocinado);
            }

            PlayerPick.sethasItem(true);
            Debug.Log(PlayerPick.gethasItem());
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
            tiempo = 0f;
        }


        if (other.gameObject.tag == "Player" && !PlayerPick.gethasItem())
        {
            extraer = true;
            Debug.Log("recoger");
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
