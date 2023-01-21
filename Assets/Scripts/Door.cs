using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Is this door a single or a double door? Choose one.")]
    [SerializeField] bool Single_door = false;
    [SerializeField] bool Double_door = false;

    [Header("Drop door hinge game objects here.")]
    [SerializeField] GameObject Hinge_One;
    [SerializeField] GameObject Hinge_Two;
    
    private float minAngle = 0.0f;
    private float maxAngle = 90.0f;

    private bool isLerpOpenSingle = false;
    private bool isLerpCloseSingle = false;
    private bool isLerpOpenDouble = false;
    private bool isLerpCloseDouble = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerpOpenSingle)
        {
            OpenSingleDoor();
            isLerpOpenSingle = false;
        }
        if (isLerpCloseSingle)
        {
            CloseSingleDoor();
            isLerpCloseSingle = false;
        }
        if (isLerpOpenDouble == true)
        {
            OpenDoubleDoor();
            isLerpOpenDouble = false;
        }
        if (isLerpCloseDouble == true)
        {
            CloseDoubleDoor();
            isLerpCloseDouble = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Single_door == true)
        {
            Debug.Log("The player has entered the collision area.");
            isLerpOpenSingle = true;
        }
        else if (other.gameObject.CompareTag("Player") && Double_door == true)
        {
            Debug.Log("The player has entered the collision area.");
            isLerpOpenDouble = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Single_door == true)
        {
            isLerpCloseSingle = true;
        }
        else if (other.gameObject.CompareTag("Player") && Double_door == true)
        {
            isLerpCloseDouble = true;            
        }
    }

    void OpenSingleDoor()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        Hinge_One.transform.eulerAngles = new Vector3(0, angle, 0);        
    }

    void CloseSingleDoor()
    {
        float angle = Mathf.LerpAngle(maxAngle, minAngle, Time.time);
        Hinge_One.transform.eulerAngles = new Vector3(0, angle, 0);        
    }
    void OpenDoubleDoor()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        Hinge_One.transform.eulerAngles = new Vector3(0, angle, 0);
        Hinge_Two.transform.eulerAngles = new Vector3(0, -angle, 0);
    }

    void CloseDoubleDoor()
    {
        float angle = Mathf.LerpAngle(maxAngle, minAngle, Time.time);
        Hinge_One.transform.eulerAngles = new Vector3(0, angle, 0);
        Hinge_Two.transform.eulerAngles = new Vector3(0, -angle, 0);
    }

}
