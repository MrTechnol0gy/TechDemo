using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    private GameObject enest; //EaglesNest locator
    Vector3 respawn_Position;

    // Start is called before the first frame update
    void Start()
    {
        enest = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn_Position = enest.GetComponent<EaglesNest>().current_Checkpoint.transform.position;
            other.transform.position = respawn_Position;
        }
    }
}
