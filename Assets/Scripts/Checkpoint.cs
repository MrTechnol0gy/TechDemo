using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 respawn_POS;
    private ParticleSystem ps;
    private GameObject enest; //EaglesNest locator

    [Header("RespawnPoint child goes here.")]
    [SerializeField] GameObject respawn_Location;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        enest = GameObject.FindWithTag("GameController");
    }       

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ps.Play();
            //Debug.Log("Particles are go.");
            enest.GetComponent<EaglesNest>().current_Checkpoint = respawn_Location;
        }
    }
}
