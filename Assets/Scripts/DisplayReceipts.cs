using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayReceipts : MonoBehaviour
{
    public GameObject Receipt1;
    public GameObject Receipt2;
    public GameObject Receipt3;

    [SerializeField] private GameObject prefabPlatoLechuga;
    [SerializeField] private GameObject prefabEnsaladaTomate;
    [SerializeField] private GameObject prefabPizzaSimple;
    [SerializeField] private GameObject prefabPizzaQueso;
    [SerializeField] private GameObject prefabHamburguesaSimple;
    [SerializeField] private GameObject prefabHamburguesaLechugaTomate;
    [SerializeField] private GameObject prefabPaella;

    public Sprite EnsaladaSimple;
    public Sprite EnsaladaCompleta;
    public Sprite PizzaSimple;
    public Sprite PizzaCompleta;
    public Sprite HamburguesaSimple;
    public Sprite HamburguesaCompleta;
    public Sprite Paella;

    

    static private float tmp1, tmp2, tmp3;
    static private int i, j, k;
    Slider Barra1, Barra2, Barra3;
    private List<string> Receipts;
    static private string nameReceta;
    static private bool entregado;

    public GameObject Player;
    GameObject myHands, next_receta;
    Vector3 pos;
    private Color valor1 = new Color(0,0,0, 0.01f);
    private Color valor2 = new Color(0, 0, 0, 0.01f);
    private Color valor3 = new Color(0, 0, 0, 0.01f);
    static string signo1;
    static string signo2;
    static string signo3;
    private Color sh = new Color(0, 0, 0, 0.0025f);

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
    void Awake()
    {
        Barra1 = GetComponentsInChildren<Slider>()[0];
        Barra2 = GetComponentsInChildren<Slider>()[1];
        Barra3 = GetComponentsInChildren<Slider>()[2];
    }
    static public void start()
    {
        i = 0;
        j = 1;
        k = 2;
        tmp1 = 60;
        tmp2 = 60;
        tmp3 = 60;
        entregado = false;
        signo1 = "+";
        signo2 = "+";
        signo3 = "+";

    }

    static public void Entregado()
    {
        entregado = true;
    }

    static public string get_nameReceta()
    {
        return nameReceta;
    } 

    void Update()
    {
        if (tmp3 <= 0)
        {
            ++k;
            tmp3 = 60;
            entregado = false;
            Receipt3.GetComponentsInChildren<Image>()[0].color = new Color(1, 0, 0, 0);
            Receipt3.GetComponentsInChildren<Image>()[3].color = new Color(1, 1, 1, 0);
            //Barra3.gameObject.SetActive(false);
        }
        if (tmp2 <= 0)
        {
            Receipt2.GetComponentsInChildren<Image>()[0].color = Receipt3.GetComponentsInChildren<Image>()[0].color;
            Receipt3.GetComponentsInChildren<Image>()[0].color = new Color(1, 0, 0, 0);
            Receipt3.GetComponentsInChildren<Image>()[3].color = new Color(1, 1, 1, 0);
            //Barra3.gameObject.SetActive(false);
            j = k;
            tmp2 = tmp3;
            ++k;
            tmp3 = 60;
            entregado = false;
        }
        if (tmp1 <= 0 || entregado)
        {
            Receipt1.GetComponentsInChildren<Image>()[0].color = Receipt2.GetComponentsInChildren<Image>()[0].color;
            Receipt2.GetComponentsInChildren<Image>()[0].color = Receipt3.GetComponentsInChildren<Image>()[0].color;
            Receipt3.GetComponentsInChildren<Image>()[0].color = new Color(1, 0, 0, 0);
            Receipt3.GetComponentsInChildren<Image>()[3].color = new Color(1, 1, 1, 0);
            //Barra3.gameObject.SetActive(false);
            Debug.Log(Barra3.value);
            i = j;
            tmp1 = tmp2;
            j = k;
            tmp2 = tmp3;
            ++k;
            tmp3 = 60;
            entregado = false;

        }

        //aparecer layout 
        if (Receipt1.GetComponentsInChildren<Image>()[3].color.a < 1)
        {
           Receipt1.GetComponentsInChildren<Image>()[3].color += sh;
            if (Receipt1.GetComponentsInChildren<Image>()[3].color.a >= 1)
            {
                //Barra1.gameObject.SetActive(true);
                //tmp1 = 60;
            }
        }
        if (Receipt2.GetComponentsInChildren<Image>()[3].color.a < 1)
        {
            Receipt2.GetComponentsInChildren<Image>()[3].color += sh;
            if (Receipt2.GetComponentsInChildren<Image>()[3].color.a >= 1)
            {
                //Barra2.gameObject.SetActive(true);
                //tmp2 = 60;
            }
        }
        if (Receipt3.GetComponentsInChildren<Image>()[3].color.a < 1)
        {
            Receipt3.GetComponentsInChildren<Image>()[3].color += sh;
            if (Receipt3.GetComponentsInChildren<Image>()[3].color.a >= 1) {
                //Barra3.gameObject.SetActive(true);
                //tmp3 = 60;
            }
        }

        tmp1 -= 1 * Time.deltaTime;
        tmp2 -= 1 * Time.deltaTime;
        tmp3 -= 1 * Time.deltaTime;

        //contorno del layout
        if (tmp1 <= 15)
        {
            if (signo1 == "-")
            {
                Receipt1.GetComponentsInChildren<Image>()[0].color -= valor1;
                valor1.a -= 25 / 255;
                if (Receipt1.GetComponentsInChildren<Image>()[0].color.a <= 0 + 0.01f )
                {
                    signo1 = "+";
                }
            }
            else
            {
                Receipt1.GetComponentsInChildren<Image>()[0].color += valor1;
                valor1.a += 25 / 255;
                if (Receipt1.GetComponentsInChildren<Image>()[0].color.a >= 1 - 0.01f)
                {
                    signo1 = "-";
                }
            }
            
        }
        if (tmp2 <= 15)
        {
            if (signo2 == "-")
            {
                Receipt2.GetComponentsInChildren<Image>()[0].color -= valor2;
                valor2.a -= 25 / 255;
                if (Receipt2.GetComponentsInChildren<Image>()[0].color.a <= 0 + 0.01f)
                {
                    signo2 = "+";
                }
            }
            else
            {
                Receipt2.GetComponentsInChildren<Image>()[0].color += valor2;
                valor2.a += 25 / 255;
                if (Receipt2.GetComponentsInChildren<Image>()[0].color.a >= 1 - 0.01f)
                {
                    signo2 = "-";
                }
            }
        }
        if (tmp3 <= 15)
        {
            if (signo3 == "-")
            {
                Receipt3.GetComponentsInChildren<Image>()[0].color -= valor3;
                valor3.a -= 25 / 255;
                if (Receipt3.GetComponentsInChildren<Image>()[0].color.a <= 0 + 0.01f)
                {
                    signo3 = "+";
                }
            }
            else
            {
                Receipt3.GetComponentsInChildren<Image>()[0].color += valor3;
                valor3.a += 25 / 255;
                if (Receipt3.GetComponentsInChildren<Image>()[0].color.a >= 1 - 0.01f)
                {
                    signo3 = "-";
                }
            }
        }

        Receipts = ReceiptController.get_recipes();
        nameReceta = Receipts[i];
        Barra1.value = tmp1;
        Barra2.value = tmp2;
        Barra3.value = tmp3;

        if (Receipts != null && Receipts[i] == "PlatoLechuga")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[i] == "EnsaladaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "PizzaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[i] == "PizzaQueso")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaLechugaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "Paella")
        {
            Receipt1.GetComponentsInChildren<Image>()[3].sprite = Paella;
        }


        if (Receipts != null && Receipts[j] == "PlatoLechuga")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[j] == "EnsaladaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "PizzaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[j] == "PizzaQueso")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaLechugaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "Paella")
        {
            Receipt2.GetComponentsInChildren<Image>()[3].sprite = Paella;
        }


        if (Receipts != null && Receipts[k] == "PlatoLechuga")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[k] == "EnsaladaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "PizzaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[k] == "PizzaQueso")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaLechugaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "Paella")
        {
            Receipt3.GetComponentsInChildren<Image>()[3].sprite = Paella;
        }




        if (next_receta == null && Input.GetKeyDown(KeyCode.P) && !PlayerPick.gethasItem())
        {
            myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
            if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "EnsaladaSimple")
            {
                next_receta = Instantiate(prefabPlatoLechuga) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "EnsaladaCompleta")
            {
                next_receta = Instantiate(prefabEnsaladaTomate) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "PizzaSimple")
            {
                next_receta = Instantiate(prefabPizzaSimple) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "PizzaQueso")
            {
                next_receta = Instantiate(prefabPizzaQueso) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "HamburguesaSimple")
            {
                next_receta = Instantiate(prefabHamburguesaSimple) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "HamburguesaCompleta")
            {
                next_receta = Instantiate(prefabHamburguesaLechugaTomate) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
            else if (Receipt1.GetComponentsInChildren<Image>()[3].sprite.name == "Paella")
            {
                next_receta = Instantiate(prefabPaella) as GameObject;
                PlayerMoviment.Recoger();
                pos = myHands.transform.position;

                orientacio();
                next_receta.transform.parent = myHands.transform;
                next_receta.GetComponent<Rigidbody>().isKinematic = true;
                next_receta.transform.position = pos;
                PlayerPick.sethasItem(true);
                PlayerPick.sethObjectIwantToPickUp(next_receta);
            }
        }




        else if (Input.GetKeyDown(KeyCode.I))
        {
            MesaCortar.change_acabar();
            Cocinar.change_acabar();
            Hornear.change_acabar();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Cocinar.change_godmode();
            Hornear.change_godmode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(5);
        }

    }


   
}
