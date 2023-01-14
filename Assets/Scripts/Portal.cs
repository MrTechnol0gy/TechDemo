using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Vector3 destination_POS;    

    [SerializeField] GameObject destination_Portal;
    [SerializeField] bool teleportPlayer = true;
    [SerializeField] bool teleportTeleporter = false;

    // Start is called before the first frame update
    void Start()
    {
        destination_POS = destination_Portal.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (teleportPlayer == true)
            {
                Debug.Log("Player is teleporting.");
                other.transform.position = destination_POS;
            }
            else if (teleportTeleporter == true)
            {
                Debug.Log("Teleporter is teleporting.");
                this.transform.position = destination_POS;
            }
        }
    }
}
