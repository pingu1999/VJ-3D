using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 2000;
    public float sideforce = 2000;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola Mundo");


        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardforce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardforce * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideforce * Time.deltaTime, 0, 0);
        }
    }
}
