using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Companion script for any object that is meant to move the player.

public class MoveLinkedPlayer : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == player)
        {
            
        }
    }
}
