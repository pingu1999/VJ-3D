using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadirIngredientes : MonoBehaviour
{
    bool lechuga, tomate, pan, pizza, queso, paella, carne;
    GameObject Object;
    GameObject _platoposcombinacion;
    [SerializeField] private GameObject prefabEnsaladaTomate, prefabHamburguesaLechugaTomate, prefabHamburguesaSimple, prefabPaella, prefabPizzaQueso;
    [SerializeField] private GameObject prefabPizzaSimple, prefabBasePizza, prefabBasePizzaTomate, prefabBasePizzaTomateQueso, prefabPlatoLechuga, prefabPan, prefabPanLechuga, prefabPanLechugaTomate;

    void Start()
    {
        
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
            Debug.Log("bien");
            Vector3 pos = gameObject.transform.position;
            Destroy(Object);
            Destroy(gameObject);

            tomate = false;
            _platoposcombinacion = Instantiate(prefabEnsaladaTomate) as GameObject;
            _platoposcombinacion.transform.position = pos;
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
            //Debug.Log("TomateCortado");
            tomate = true;
            Object = other.gameObject;

       }

    }
}
