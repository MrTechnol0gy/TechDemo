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
        InvokeRepeating("MakeWeapon", 3, 1);
    }

    private void MakeWeapon()
    {
        Rigidbody spawnedInstance;
        spawnedInstance = Instantiate(spawnedItem, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
        spawnedInstance.AddForce(spawnPoint.up * spawn_Speed * Time.deltaTime);
        //spawnedInstance.AddRotation(spawnPoint.up, spawnPoint.rotation);
    }
}
