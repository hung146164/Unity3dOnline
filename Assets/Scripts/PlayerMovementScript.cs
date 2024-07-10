using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private CharacterController controller;

    //Speed Player Move
    public float speedMove = 12f;
    //Gravity
    public float gravity = -9.81f * 2;
    //JumpHeight
    public float jumpHeight=3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    //Ground check
    bool isGrounded;
    //Move check
    bool isMoving;


    Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        controller=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        float xInput=Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;
        move.Normalize();
        controller.Move(move*speedMove*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if(lastPosition!=gameObject.transform.position && isGrounded==true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = gameObject.transform.position;
    }
}
