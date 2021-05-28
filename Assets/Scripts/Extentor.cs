using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extentor : MonoBehaviour
{
    bool apagar, enMano;
    static bool encencido;
    public AudioSource song;
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
            song.mute = false;
            encencido = true;
            transform.Find("Particulas").gameObject.SetActive(true);
            apagar = false;
            
        }

        else if (enMano && !apagar && Input.GetKeyDown(KeyCode.Q))
        {
            song.mute = true;
            transform.Find("Particulas").gameObject.SetActive(false);
            encencido = false;
            apagar = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && transform.parent != null)
        {
            apagar = true;
            enMano = true;
        }
        else
        {
            song.mute = true;
            enMano = false;
            transform.Find("Particulas").gameObject.SetActive(false);
        }

    }

}
