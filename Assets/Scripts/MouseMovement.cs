using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    //mouse sensitivity
    public float mouseSensitivity = 500f;

   //rotation value Xaxis
    float xRotation = 0f;
    //rotation value Yaxis
    float yRotation = 0f;
    //rotation value Zaxis
    float zRotation = 0f;
    public float topClamp = -90f; 

    public float bottomClamp = 90f;

    private void Start()
    {
        //This line locks the mouse pointer to the center of the screen and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Get mouse X axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //Get mouse Y axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Look Up and Down
        xRotation -= mouseY;
        //Look Right and Left
        yRotation += mouseX;
        //Limit raising and bending the head
        xRotation=Mathf.Clamp(xRotation,topClamp,bottomClamp);

        transform.localRotation = Quaternion.Euler(xRotation,yRotation, zRotation);
    }
}
