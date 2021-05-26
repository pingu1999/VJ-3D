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
        ReceiptController.change_scene();
        i = 0;
        j = 1;
        k = 2;
        tmp1 = 0;
        tmp2 = 0;
        tmp3 = 0;
        entregado = false;
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
        if (tmp1 > 40 || entregado)
        {
            i = j;
            tmp1 = tmp2;
            j = k;
            tmp2 = tmp3;
            ++k;
            tmp3 = 0;
            entregado = false;

        }

        tmp1 += 1 * Time.deltaTime;
        tmp2 += 1 * Time.deltaTime;
        tmp3 += 1 * Time.deltaTime;

        Receipts = ReceiptController.get_recipes();
        nameReceta = Receipts[i];
        Barra1.value = tmp1;
        Barra2.value = tmp2;
        Barra3.value = tmp3;

        if (Receipts != null && Receipts[i] == "PlatoLechuga")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[i] == "EnsaladaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "PizzaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[i] == "PizzaQueso")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaSimple")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[i] == "HamburguesaLechugaTomate")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[i] == "Paella")
        {
            Receipt1.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }


        if (Receipts != null && Receipts[j] == "PlatoLechuga")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[j] == "EnsaladaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "PizzaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[j] == "PizzaQueso")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaSimple")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[j] == "HamburguesaLechugaTomate")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[j] == "Paella")
        {
            Receipt2.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }



        if (Receipts != null && Receipts[k] == "PlatoLechuga")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = EnsaladaSimple;
        }
        else if (Receipts != null && Receipts[k] == "EnsaladaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = EnsaladaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "PizzaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = PizzaSimple;
        }
        else if (Receipts != null && Receipts[k] == "PizzaQueso")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = PizzaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaSimple")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = HamburguesaSimple;
        }
        else if (Receipts != null && Receipts[k] == "HamburguesaLechugaTomate")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = HamburguesaCompleta;
        }
        else if (Receipts != null && Receipts[k] == "Paella")
        {
            Receipt3.GetComponentsInChildren<Image>()[2].sprite = Paella;
        }




        if (next_receta == null && Input.GetKeyDown(KeyCode.P) && !PlayerPick.gethasItem())
        {
            myHands = Player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
            if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "EnsaladaSimple")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "EnsaladaCompleta")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "PizzaSimple")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "PizzaQueso")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "HamburguesaSimple")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "HamburguesaCompleta")
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
            else if (Receipt1.GetComponentsInChildren<Image>()[2].sprite.name == "Paella")
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
            Debug.Log(1);
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(2);
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(3);
            SceneManager.LoadScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(4);
            SceneManager.LoadScene(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log(5);
            SceneManager.LoadScene(5);
        }

    }


   
}
