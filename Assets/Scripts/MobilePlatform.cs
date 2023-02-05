using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{

    private float _startPositionz;
    private float _startPositionx;
    private float _startPositiony;
    private float t = 0.0f;
    private bool platformRise = true;
    private bool platformFall = false;
    private bool platformLeft = true;
    private bool platformRight = false;
    private bool platformForward = true;
    private bool platformBackward = false;

    [SerializeField] GameObject platform;
    [SerializeField] float platformDistance = 5.0f;
    [SerializeField] bool UpDown = false;
    [SerializeField] bool LeftRight = false;
    [SerializeField] bool ForwardBackward = false;
    [SerializeField] int delay = 0; //doesn't work above zero, introduces stutters

    // Start is called before the first frame update
    void Start()
    {
        _startPositionz = platform.transform.localPosition.z;
        _startPositiony = platform.transform.localPosition.y;
        _startPositionx = platform.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpDown == true)
        {
            if (platformRise == true)
            {
                Invoke("PlatformUp", delay);
            }
            else if (platformFall == true)
            {
                Invoke("PlatformDown", delay);
            }
        }
        else if (LeftRight == true)
        {
            if (platformLeft == true)
            {
                Invoke("PlatformLeft", delay);
            }
            else if (platformRight == true)
            {
                Invoke("PlatformRight", delay);
            }
        }
        else if (ForwardBackward == true)
        {
            if (platformForward == true)
            {
                Invoke("PlatformForward", delay);
            }
            else if (platformBackward == true)
            {
                Invoke("PlatformBackward", delay);
            }
        }
    }
    void PlatformUp()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(_startPositiony, platformDistance, t);
        platform.transform.localPosition = new Vector3(_startPositionx, distance, _startPositionz);
        if (t > 1.0f)
        {
            platformRise = false;
            t = 0.0f;
            platformFall = true;
        }
    }
    void PlatformDown()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(platformDistance, -_startPositiony, t);
        platform.transform.localPosition = new Vector3(_startPositionx, distance, _startPositionz);
        if (t > 1.0f)
        {
            platformFall = false;
            t = 0.0f;
            platformRise = true;
        }
    }
    void PlatformLeft()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(_startPositionx, platformDistance, t);
        platform.transform.localPosition = new Vector3(distance, 0, 0);
        if (t > 1.0f)
        {
            platformLeft = false;
            t = 0.0f;
            platformRight = true;
        }
    }
    void PlatformRight()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(platformDistance, -_startPositionx, t);
        platform.transform.localPosition = new Vector3(distance, 0, 0);
        if (t > 1.0f)
        {
            platformRight = false;
            t = 0.0f;
            platformLeft = true;
        }
    }
    void PlatformForward()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(_startPositionz, platformDistance, t);
        platform.transform.localPosition = new Vector3(0, 0, distance);
        if (t > 1.0f)
        {
            platformForward = false;
            t = 0.0f;
            platformBackward = true;
        }
    }
    void PlatformBackward()
    {
        t += 0.5f * Time.deltaTime;
        float distance = Mathf.SmoothStep(platformDistance, -_startPositionz, t);
        platform.transform.localPosition = new Vector3(0, 0, distance);
        if (t > 1.0f)
        {
            platformBackward = false;
            t = 0.0f;
            platformForward = true;
        }
    }
}