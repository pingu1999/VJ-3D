using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{

    //variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;

    static public string dir;
    public Canvas layout;
    private Vector3 moveDirection;
    private Vector3 velocity;
    static bool block;
    
    private CharacterController controller;
    private static Animator anim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        block = false;
        anim.SetBool("recoger", false);

    }
    public static string Direccio()
    {
        return dir;
    }

    static public void setblock (bool b)
    {
        block = b;
    }


    void Update()
    {
       
        Move();
    }
    private void Move()
    {
        
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

       
        if (!block)
        {
            gir_personatge(moveZ, moveX);
            moveDirection = new Vector3(moveX, 0, moveZ);
        }
        if (moveDirection == Vector3.zero)
        {
            Idle();
        }
        
        else if (moveDirection != Vector3.zero)
        {
            layout.gameObject.SetActive(true);
            walk();
        }


        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
       
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

    }
    public static void Recoger()
    {

        anim.SetBool("recoger",!anim.GetBool("recoger"));
       
        
    }



    private void gir_personatge(float moveZ, float moveX)
    {
        //Quaternion rotation;
        if (moveZ == 0 && moveX == 0)
        {
           //idle
           //no hay que rotar
        }


        else if (moveZ > 0 && moveX == 0)
        {
            //delante
            transform.rotation = Quaternion.Euler(0, 0, 0);
            dir = "north";
        }
        else if (moveZ < 0 && moveX == 0)
        {
            //detras
            transform.rotation = Quaternion.Euler(0, 180, 0);
            dir = "south";
        }
        else if (moveZ == 0 && moveX > 0)
        {
            //derecha
            transform.rotation = Quaternion.Euler(0, 90, 0);
            dir = "est";
        }
        else if (moveZ == 0 && moveX < 0)
        {
            //izquierda
            transform.rotation = Quaternion.Euler(0, -90, 0);
            dir = "west";
        }



        else if (moveZ > 0 && moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
            dir = "north-west";
        }
        else if (moveZ > 0 && moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            dir = "north-est";
        }
        else if (moveZ < 0 && moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
            dir = "south-west";
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
            dir = "south-est";
        }
       //Debug.Log(dir);
    }
}
