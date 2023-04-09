using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesNest : MonoBehaviour
{
    //Master Script for controlling/referencing key elements and items across the level.

    [Header("Player Checkpoint")]
    [SerializeField] public GameObject current_Checkpoint;
        
    [Header("Collectibles")]
    [SerializeField] int door_Keys = 0;
    [SerializeField] int potion = 0;
    [SerializeField] int crystal = 0;

}
