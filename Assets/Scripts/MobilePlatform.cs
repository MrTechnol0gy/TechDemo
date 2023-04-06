using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] private GameObject start, destination;
    [SerializeField] private float _speed = 1.0f;

    private bool _switch = false;
    private bool _start = false;
    private float t = 0.0f;
    private Vector3 startPos, endPos;

    // Start is called before the first frame update
    void Start()
    {
        _start = true;
        startPos = start.transform.position;
        endPos = destination.transform.position; //a transform is not a vector3, but a transform.position is
    }

    // Update is called once per frame
    void Update()
    {
        if (_start)
        {
            if (_switch == false)
            {
                PlatformGo();
            }
            else if (_switch == true)
            {
                PlatformCome();
            }
        }
    }

    void PlatformGo()
    {        
        t += 0.5f * Time.deltaTime * _speed;
        transform.localPosition = Vector3.Lerp(startPos, endPos, t);
        if (t > 1.0f)
        {
            _switch = true;
            t = 0.0f;
            //Debug.Log("go");
        }
        
    }
    void PlatformCome()
    {
        t += 0.5f * Time.deltaTime * _speed;
        transform.localPosition = Vector3.Lerp(endPos, startPos, t);
        if (t > 1.0f)
        {
            _switch = false;
            t = 0.0f;
            //Debug.Log("come");
        }
    }
}