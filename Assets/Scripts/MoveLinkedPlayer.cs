using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Companion script for any object that is meant to move the player.

public class MoveLinkedPlayer : MonoBehaviour
{
    private GameObject player;     
    [SerializeField] GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            other.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            Debug.Log("Player no move");
            other.gameObject.transform.parent = null;
        }
    }
}
