using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour

{
    public Rigidbody spawnedItem;
    public Transform spawnPoint;
    [SerializeField] float spawn_Speed = 0f;
    [SerializeField] int spawn_Amount = 0;
    [SerializeField] bool destroy_Script = false;
    [SerializeField] bool destroy_GameObject = false;
    [SerializeField] bool destroy_Reality = false;

    private int i = 0;

    void Start()
    {

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (i < spawn_Amount)
        {
            Invoke("MakeWeapon", 1);
            i++;
        }
    }

    private void MakeWeapon()
    {
        Rigidbody spawnedInstance;
        spawnedInstance = Instantiate(spawnedItem, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
        spawnedInstance.AddForce(spawnPoint.up * spawn_Speed * Time.deltaTime);
        if (destroy_Script == true)
        {
            Destroy(this, 2.5f); //this destroys the script component, which is hilarious
        }
        else if (destroy_GameObject == true)
        {
            Destroy(gameObject, 2); //this destroys the spawner itself
        }
        else if (destroy_Reality == true)
        {
            Destroy(spawnedInstance, 2); //this freezes the spawned item 2 seconds after it is spawned.
        }
        //GameObject.Destroy(spawnedInstance, 1); //seems to do same as above
    }
}
