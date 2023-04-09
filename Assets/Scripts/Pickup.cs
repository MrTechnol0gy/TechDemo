using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] string pickupName;
    [SerializeField] bool repeatable = false;
    [SerializeField] int respawn_Timer = 1;

    private GameObject enest; //EaglesNest locator
    private AudioSource sfx;
    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        enest = GameObject.FindWithTag("GameController");
        sfx = GetComponent<AudioSource>();
        pickup = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && repeatable == false)
        {
            sfx.Play();
            enest.GetComponent<EaglesNest>().IncreasePickUp(pickupName);
            Invoke("DeactivateMe", 0.1f);            
        }
        else if (other.gameObject.CompareTag("Player") && repeatable == true)
        {
            
            sfx.Play();
            enest.GetComponent<EaglesNest>().IncreasePickUp(pickupName);
            Invoke("DeactivateMe", 0.1f);            
            Invoke("respawn_Pickup", respawn_Timer);
        }
    }

    private void respawn_Pickup()
    {        
        pickup.SetActive(true);
    }

    private void DeactivateMe()
    {        
        pickup.SetActive(false);
    }
}
