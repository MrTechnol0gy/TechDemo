using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Companion script for any object that is meant to move the player.

public class MoveLinkedPlayer : MonoBehaviour
{
    private GameObject player; 
    private Vector3 _startPosition;
    private Vector3 _playerentryPOS;
    [SerializeField] GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            //this.gameObject.transform.parent = platform.transform;
            Debug.Log("Player go move");
            _playerentryPOS = player.transform.position;
            player.transform.position = this.transform.position - _playerentryPOS;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            Debug.Log("Player no move");
            player.transform.position = player.transform.position;
        }
    }
}
