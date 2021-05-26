using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extentor : MonoBehaviour
{
    bool apagar, enMano;
    static bool encencido;
   void Start()
    {
        apagar = false;
        encencido = false;
        enMano = false;
    }
    static public bool get_encendido()
    {
        return encencido;
    }

    void Update()
    {
        if (enMano && apagar && Input.GetKeyDown(KeyCode.Q))
        {

            Debug.Log(transform.Find("Particulas"));
            encencido = true;
            transform.Find("Particulas").gameObject.SetActive(true);
            apagar = false;
            
        }

        else if (enMano && !apagar && Input.GetKeyDown(KeyCode.Q))
        {
            transform.Find("Particulas").gameObject.SetActive(false);
            encencido = false;
            apagar = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && transform.parent != null)

        {

            Debug.Log("entra");
            apagar = true;
            enMano = true;
        }
        else
        {
            enMano = false;
            transform.Find("Particulas").gameObject.SetActive(false);
        }

    }

}
