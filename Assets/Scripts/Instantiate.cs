using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour

{
    public Rigidbody spawnedItem;
    public Transform spawnPoint;
    [SerializeField] float spawn_Speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 10; i++)
        {
            Invoke("MakeWeapon", 2);
        }
    }

    private void MakeWeapon()
    {
        Rigidbody spawnedInstance;
        spawnedInstance = Instantiate(spawnedItem, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
        spawnedInstance.AddForce(spawnPoint.up * spawn_Speed * Time.deltaTime);
        //Destroy(this, 2.5f); //this destroys the script component, which is hilarious
        //Destroy(gameObject, 2); //this destroys the spawner itself
        //Destroy(spawnedInstance, 2); //this freezes the spawned item 2 seconds after it is spawned.
        //GameObject.Destroy(spawnedInstance, 1); //seems to do same as above
    }
}
