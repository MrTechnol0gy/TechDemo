using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //ref: Code like Me https://www.youtube.com/channel/UCU9YE0hMnTt6TozuyVKicHA

    private float forwardInput;
    private float rightInput;

    public CameraController cameraController;
    public PlayerMovement playerMovement;

    private Vector3 velocity;
    private bool jumping = false;
    private bool crouching = false;

    public Image RunToggleUI;
    public Image CrouchToggleUI;

    public Text velocityText;

    // Update is called once per frame
    void Update()
    {
        velocityText.text = getVelocity().ToString("#.00"); ;
    }

    public void AddMovementInput(float forward, float right)    // update movement inputs
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 camRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;
        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        playerMovement.Velocity = translation;

    }

    public float getVelocity()
    {
        return playerMovement.Velocity.magnitude;
    }

    public bool getJump()
    {
        return jumping;
    }

    public bool getCrouch()
    {
        return crouching;
    }

    public void ToggleRun()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Running && playerMovement.GetMovementMode() != MovementMode.Crouching)
        {
            playerMovement.SetMovementMode(MovementMode.Running);
            RunToggleUI.GetComponent<Image>().color = Color.green;
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
            RunToggleUI.GetComponent<Image>().color = Color.red;
        }
    }
    public void ToggleCrouch()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Crouching && playerMovement.GetMovementMode() != MovementMode.Running)
        {
            crouching = true;
            playerMovement.SetMovementMode(MovementMode.Crouching);
            CrouchToggleUI.GetComponent<Image>().color = Color.green;
        }
        else 
        {
            crouching = false;
            playerMovement.SetMovementMode(MovementMode.Walking);
            CrouchToggleUI.GetComponent<Image>().color = Color.red;
        }
    }
    public void ToggleJump()
    {
        if (jumping == false)
        {
            jumping = true;
            Invoke("ToggleJump", 0.1f);
        }
        else 
        {
            jumping = false;
        }
    }
}
