using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
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
    private float t = 0.0f;

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
        if (isLerpOpenSingle == true)
        {
            OpenSingleDoor();            
        }
        if (isLerpCloseSingle == true)
        {
            CloseSingleDoor();            
        }
        if (isLerpOpenDouble == true)
        {            
            OpenDoubleDoor();
        }
        if (isLerpCloseDouble == true)
        {
            CloseDoubleDoor();            
        }
    }

    void OnTriggerEnter(Collider other) //opens the door when the player enters the collider area
    {
        if (other.gameObject.CompareTag("Player") && Single_door == true)
        {            
            isLerpOpenSingle = true;
        }
        else if (other.gameObject.CompareTag("Player") && Double_door == true)
        {            
            isLerpOpenDouble = true;
        }
    }
    void OnTriggerExit(Collider other) //closes the door when the player exits the collider area
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
        t += 0.5f * Time.deltaTime;
        float angle = Mathf.SmoothStep(minAngle, maxAngle, t);
        Hinge_One.transform.localEulerAngles = new Vector3(0, angle, 0);
        if (t > 1.0f)
        {
            isLerpOpenSingle = false;
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
            isLerpCloseSingle = false;
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
            isLerpOpenDouble = false;
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
            isLerpCloseDouble = false;
            t = 0.0f;
        }
    }
}
