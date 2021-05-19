using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCarne;
    private GameObject _carne;


    void Start()
    {
        
    }

    void Update()
    {
        if (_carne == null)
        {
            Vector3 pos = this.transform.position;
            pos.y += 15.0f; 
            _carne = Instantiate(prefabCarne) as GameObject;
            _carne.transform.position = pos;
               
        }
        
    }
}
