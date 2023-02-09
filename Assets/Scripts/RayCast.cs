using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    //https://gamedevbeginner.com/raycasts-in-unity-made-easy/

    //this raycast is designed to make an object float

    public Rigidbody rb;
    [SerializeField] int forceToApply; //should be at least 10* the objects mass

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 2))
        {
            FloatUp();
        }
    }

    void FloatUp()
    {
        Vector3 forceAmount = new Vector3(0, forceToApply, 0);
        rb.AddForce(forceAmount);
    }

}
