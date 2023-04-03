using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Door : MonoBehaviour
{
    enum DoorState
    {
        open,           // Door is fully open = 0        
        closed,         // Door is fully closed = 1
        opening,        // Door is in the process of opening = 2
        closing         // Door is in the process of closing = 3
    }
    [Header("Is this door a single or a double door? Choose one.")]
    [SerializeField] bool Single_door = false;
    [SerializeField] bool Double_door = false;

    [Header("Drop door hinge game objects here.")]
    [SerializeField] GameObject Hinge_One;
    [SerializeField] GameObject Hinge_Two;

    [Header("Door Audio")]
    [SerializeField] AudioSource Door_Open;
    [SerializeField] AudioSource Door_Close;
    
    private float minAngle = 0.0f;
    private float maxAngle = 90.0f;
    private float t = 0.0f;
    private bool active;                // used to prevent multiple stacking 'ontriggerenters'

    DoorState doorState = DoorState.closed;
    
    void FixedUpdate()
    {
        StateProceed();
    }    

    private void StateProceed()
    {
        switch (doorState)
        {
            case DoorState.opening:
            {
                if (Single_door == true)
                {
                    OpenSingleDoor();
                }
                else if (Double_door == true)
                {
                    OpenDoubleDoor();
                }
            }
            break;
            case DoorState.closing:
            {
                if (Single_door == true)
                {
                    CloseSingleDoor();
                }
                else if (Double_door == true)
                {
                    CloseDoubleDoor();
                }
            }
            break;
            default:
            break;
        }
    }
    IEnumerator OnTriggerEnter(Collider other) //opens the door when the player enters the collider area
    {
        if (other.gameObject.CompareTag("Player") && active == false)
        {
            active = true;
            if (doorState != DoorState.closing && doorState != DoorState.opening)
            {
                doorState = DoorState.opening;
                Door_Open.Play();
            }
            else 
            {
                yield return new WaitUntil(() => doorState == DoorState.closed);
                doorState = DoorState.opening;
                Door_Open.Play();
            }
        }        
    }
    IEnumerator OnTriggerExit(Collider other) //closes the door when the player exits the collider area
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorState != DoorState.opening && doorState != DoorState.closing)
            {
                doorState = DoorState.closing;
                Door_Close.Play();
            }
            else
            {
                yield return new WaitUntil(() => doorState == DoorState.open);
                doorState = DoorState.closing;
                Door_Close.Play();
            }
        }
        active = false;
    }

    void OpenSingleDoor()
    {
        t += 0.5f * Time.deltaTime;
        float angle = Mathf.SmoothStep(minAngle, maxAngle, t);
        Hinge_One.transform.localEulerAngles = new Vector3(0, angle, 0);
        if (t > 1.0f)
        {
            doorState = DoorState.open;
            t = 0.0f;
        }
    }

    void CloseSingleDoor()
    {
        t += 0.5f * Time.deltaTime;
        float angle = Mathf.SmoothStep(maxAngle, minAngle, t);
        Hinge_One.transform.localEulerAngles = new Vector3(0, angle, 0);
        if (t > 1.0f)
        {
            doorState = DoorState.closed;
            t = 0.0f;
        }
    }
    void OpenDoubleDoor()
    {                
        t += 0.5f * Time.deltaTime;
        float angle = Mathf.SmoothStep(minAngle, maxAngle, t);        
        Hinge_One.transform.localEulerAngles = new Vector3(0, angle, 0);
        Hinge_Two.transform.localEulerAngles = new Vector3(0, -angle, 0); 
        if (t > 1.0f)
        {
            doorState = DoorState.open;
            t = 0.0f;
        }
    }

    void CloseDoubleDoor()
    {
        t += 0.5f * Time.deltaTime;
        float angle = Mathf.SmoothStep(maxAngle, minAngle, t);
        Hinge_One.transform.localEulerAngles = new Vector3(0, angle, 0);
        Hinge_Two.transform.localEulerAngles = new Vector3(0, -angle, 0);
        if (t > 1.0f)
        {
            doorState = DoorState.closed;
            t = 0.0f;
        }
    }
}
