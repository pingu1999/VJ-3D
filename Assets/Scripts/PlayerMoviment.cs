using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    //variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask gravity;

    //references
    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Recoger();
        }
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        gir_personatge(moveZ, moveX);

        moveDirection = new Vector3(moveX, 0, moveZ);

        if (moveDirection == Vector3.zero)
        {
            Idle();
        }
        
        else if (moveDirection != Vector3.zero)
        {
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
    private void Recoger()
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
        }
        else if (moveZ < 0 && moveX == 0)
        {
            //detras
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveZ == 0 && moveX > 0)
        {
            //derecha
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveZ == 0 && moveX < 0)
        {
            //izquierda
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }



        else if (moveZ > 0 && moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if (moveZ > 0 && moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else if (moveZ < 0 && moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
        }
    }
}
