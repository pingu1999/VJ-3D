using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinacionesSarten : MonoBehaviour
{

    GameObject myHands; //reference to your hands/the position where you want your object to go
    bool fusionarcarne_sarten; //a bool to see if you fusionate them
    GameObject Object; // the gameobject onwhich you collided with
    private Vector3 pos;
    public GameObject player;
    [SerializeField]
    private GameObject prefabSartenCarne;
    private GameObject _sartencarne;


    void Start()
    {
        myHands = player.transform.Find("mixamorig:Hips").Find("mixamorig:Spine").gameObject;
    }

    void Update()
    {
        if (fusionarcarne_sarten)
        {
            fusionarcarne_sarten = false;
            pos = gameObject.transform.position;
            //new WaitForSeconds(0.5f);
            Destroy(Object);
            Destroy(gameObject);
            //Object.transform.parent = null;
            _sartencarne = Instantiate(prefabSartenCarne) as GameObject;
            _sartencarne.transform.position = pos;
            


        }
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "CarneCortada" && other.transform.parent == null)
        {
            Debug.Log("Combinacion");
            fusionarcarne_sarten = true;
            Object = other.gameObject;
          
        } 
            
    }
   
}
