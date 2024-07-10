using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovementScript movement;
    public MouseMovement mouseMovement;
    public GameObject camera;
    public void IsLocalPlayer()
    {
        movement.enabled = true;
        mouseMovement.enabled = true;
        camera.SetActive(true);
    }
}
