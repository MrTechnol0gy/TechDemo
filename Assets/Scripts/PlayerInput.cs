using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{

    private Player player;
    private PlayerMovement playerMovement;

    public GameObject pauseScreen;
    public GameObject playerPanel;

    [SerializeField] GameObject currentInterObj = null;
    [SerializeField] InteractionObject currentInterObjScript = null;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        player.AddMovementInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerMovement.GetMovementMode() != MovementMode.Crouching)
        {
            player.ToggleRun();
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && playerMovement.GetMovementMode() != MovementMode.Running)
        {
            player.ToggleCrouch();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.ToggleJump();
        }
        if (Input.GetKeyDown(KeyCode.F) && currentInterObj == true)
        {
            CheckInteraction();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
            if (!pauseScreen.activeInHierarchy)
            {
                //Debug.Log("Paused.");
                pauseScreen.SetActive(true);
                playerPanel.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                //Debug.Log("Unpaused.");
                pauseScreen.SetActive(false);
                playerPanel.SetActive(true);
                Time.timeScale = 1f;
            }
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = null;
            currentInterObjScript = null;
        }
    }
    public void CheckInteraction()
    {
       currentInterObjScript.DebugTest();
       if (currentInterObjScript.interType == InteractionObject.InteractableType.nothing)
       {
            currentInterObjScript.Nothing();
       }
       else if (currentInterObjScript.interType == InteractionObject.InteractableType.info)
       {
            currentInterObjScript.Info();
       }       
       else if (currentInterObjScript.interType == InteractionObject.InteractableType.dialogue)
       {
            currentInterObjScript.Dialogue();
       }
    }
}
