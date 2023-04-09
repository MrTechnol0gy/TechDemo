using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesNest : MonoBehaviour
{
    //Master Script for controlling/referencing key elements and items across the level.

    [Header("Player Checkpoint")]
    [SerializeField] public GameObject current_Checkpoint;
        
    [Header("Collectibles")]
    string DoorKeys;
    [SerializeField] int door_Keys = 0;
    string Potion;
    [SerializeField] int potion = 0;
    string Crystal;
    [SerializeField] int crystal = 0;
    
    public int GetAmount(string name)
    {
        if (name == "Key")
        {
            return door_Keys;
        }
        else if (name == "Potion")
        {
            return potion;
        }
        else if (name == "Crystal")
        {
            return crystal;
        }
        else
        {
            return 0;
        }
    }

    public void IncreasePickUp (string name)
    {
        if (name == "Key")
        {
            door_Keys++;
        }
        else if (name == "Potion")
        {
            potion++;
        }
        else if (name == "Crystal")
        {
            crystal++;
        }        
    }

    public void DecreasePickUp (string name)
    {
        if (name == "Key")
        {
            door_Keys--;
        }
        else if (name == "Potion")
        {
            potion--;
        }
        else if (name == "Crystal")
        {
            crystal--;
        }        
    }
}
