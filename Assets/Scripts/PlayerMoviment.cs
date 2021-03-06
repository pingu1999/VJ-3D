using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{

    //variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private GameObject player;

    static public string dir;
    public Canvas layout;
    private Vector3 moveDirection;
    private Vector3 velocity;
    static bool block;
    static public bool quieto;

    private CharacterController controller;
    private static Animator anim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        block = false;
        anim.SetBool("recoger", false);
        quieto = true;

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
            moveDirection = new Vector3(moveX, 0, moveZ);
            gir_personatge(moveZ, moveX);
        }

        if (moveDirection == Vector3.zero)
        {
            quieto = true;
            Idle();
            player.transform.Find("ParticulasPlayer").gameObject.SetActive(false);quieto = true;
        }
        
        else if (moveDirection != Vector3.zero)
        {
            quieto = false;
            walk();
            player.transform.Find("ParticulasPlayer").gameObject.SetActive(true);
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
        if (moveZ == 0 && moveX == 0 && !block)
        {
           //idle
           //no hay que rotar
        }


        else if (moveZ > 0 && moveX == 0 && !block)
        {
            //delante
            transform.rotation = Quaternion.Euler(0, 0, 0);
            dir = "north";
        }
        else if (moveZ < 0 && moveX == 0 && !block)
        {
            //detras
            transform.rotation = Quaternion.Euler(0, 180, 0);
            dir = "south";
        }
        else if (moveZ == 0 && moveX > 0 && !block)
        {
            //derecha
            transform.rotation = Quaternion.Euler(0, 90, 0);
            dir = "est";
        }
        else if (moveZ == 0 && moveX < 0 && !block)
        {
            //izquierda
            transform.rotation = Quaternion.Euler(0, -90, 0);
            dir = "west";
        }



        else if (moveZ > 0 && moveX > 0 && !block)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
            dir = "north-west";
        }
        else if (moveZ > 0 && moveX < 0 && !block)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            dir = "north-est";
        }
        else if (moveZ < 0 && moveX > 0 && !block)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
            dir = "south-west";
        }
        else if (!block)
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
            dir = "south-est";
        }
       //Debug.Log(dir);
    }
}
