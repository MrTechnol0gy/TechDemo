using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] bool repeatable = false;
    [SerializeField] int respawn_Timer = 1;

    private GameObject enest; //EaglesNest locator
    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        enest = GameObject.FindWithTag("GameController");
        pickup = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && repeatable == false)
        {
            this.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && repeatable == true)
        {
            //pickup.GetComponent<MeshRenderer>().enabled = false;
            //pickup.GetComponent<SphereCollider>().enabled = false;
            pickup.SetActive(false);
            Invoke("respawn_Pickup", respawn_Timer);
        }
    }

    private void respawn_Pickup()
    {
        //pickup.GetComponent<MeshRenderer>().enabled = true;
        //pickup.GetComponent<SphereCollider>().enabled = true;
        pickup.SetActive(true);
    }
}
