using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocinar : MonoBehaviour
{
    GameObject producte, myHands, menjar;
    static string estat;
    private float tiempo, tmp;
    private bool product, extraer, apagar;
    string input;
    static bool godmode, acabar;
    [SerializeField] private GameObject prefabCarneCocinada;
    [SerializeField] private GameObject prefabCarne;

    [SerializeField] private GameObject prefabPaella;
    [SerializeField] private GameObject prefabSartenArrozTomateCarneCebollaGambas;

    [SerializeField] private GameObject prefabSartenQuemada;

    [SerializeField] private GameObject Player;
    Vector3 pos;
    public AudioSource song;


    static public void change_acabar()
    {
        acabar = !acabar;
    }

    static public void change_godmode()
    {
        godmode = !godmode;
    }

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
    public static string get_estat()
    {
        return estat;
    }

    void Update()
    {
    
        if (producte != null && estat == "apagat" && product)
        {
            estat = "cocinando";
            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(true);
        }
        if ((acabar && product) || (estat == "cocinando" && product && tiempo > 5.0f))
        {
            Vector3 posicion = producte.transform.position;
            Quaternion rotation = producte.transform.rotation;
            Destroy(producte);
            if (input == "SartenCarne")
            {
                menjar = Instantiate(prefabCarneCocinada) as GameObject;
            }
            else if (input == "SartenArrozTomateCarneCebollaGambas")
            {
                menjar = Instantiate(prefabPaella) as GameObject;
            }
            menjar.transform.parent = transform;
            menjar.GetComponent<Rigidbody>().isKinematic = true;
            menjar.transform.position = posicion;
            menjar.transform.rotation = rotation;
           

            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoCasi").gameObject.SetActive(true);
            estat = "cocinado";
        }
        if (!acabar && estat == "cocinado" && product && tiempo > 7.5f && !godmode)
        {
            Vector3 posicion = menjar.transform.position;
            Quaternion rotation = menjar.transform.rotation;
            Destroy(menjar);

            menjar = Instantiate(prefabSartenQuemada);


            menjar.transform.parent = transform;
            menjar.GetComponent<Rigidbody>().isKinematic = true;
            menjar.transform.position = posicion;
            menjar.transform.rotation = rotation;
            

            transform.Find("ParticulasFuegoCasi").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(true);
            estat = "quemado";
        }
        if (!acabar && estat == "quemado" && product && apagar && Extentor.get_encendido())
        {
            song.mute = true;
            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoCasi").gameObject.SetActive(false);
            estat = "apagat_qu";
            menjar.transform.parent = null;
        }

        if (extraer && Input.GetKeyDown(KeyCode.E) && estat != "quemado")
        {
            song.mute = true;
            transform.Find("ParticulasFuegoNormal").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoQuemado").gameObject.SetActive(false);
            transform.Find("ParticulasFuegoCasi").gameObject.SetActive(false);
           
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
            input = other.tag;

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
            song.mute = false;
            song.Play();
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