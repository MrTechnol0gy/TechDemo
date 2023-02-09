using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController_2 : MonoBehaviour
{
    PlayerController controls; //creates a reference for the controls (controls.Player.etc etc)
    //https://medium.com/nerd-for-tech/new-unity-input-system-scripting-actions-aa447c2cc84d
    Vector2 m_Move;
    Vector3 m_Rotate; //workshopping
    Vector2 m_Look;
    Rigidbody m_Rigidbody;

    bool sprint = false;

    public GameObject pauseScreen;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float m_Thrust = 20f;

    private float _rotateSpeed = 50f;    

    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Move.performed += ctx => m_Move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => m_Move = Vector2.zero;
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputValue value)
    {
        m_Move = value.Get<Vector2>();
    }

    // public void OnRotate(InputValue value)
    // {
    //     m_Rotate = value.Get<Vector3>();
    // }

    public void OnLook(InputValue value)
    {
        m_Look = value.Get<Vector2>();
    }

    public void OnJump()
    {
        m_Rigidbody.AddForce(0, m_Thrust * 10, 0);
    }

    public void OnSprint()
    {       
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)   
        {
            if (sprint == false)
            {
                sprint = true;
            }
            else 
            {
                sprint = false;
            }
        }        
    }

    public void OnButtons()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseUnpause();
        }
        else if (Gamepad.current.startButton.wasPressedThisFrame)
        {
            PauseUnpause();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (sprint == false)
        {
            Vector3 movement = new Vector3(m_Move.x, 0.0f, m_Move.y) * moveSpeed * Time.deltaTime;
            m_Rigidbody.AddRelativeForce(movement * moveSpeed, ForceMode.Force);
        }
        else if (sprint == true)
        {
            Vector3 movement = new Vector3(m_Move.x, 0.0f, m_Move.y) * moveSpeed * Time.deltaTime; 
            m_Rigidbody.AddRelativeForce(movement * moveSpeed * 2, ForceMode.Force);
        }
        float rotateDirection = controls.Player.Rotate.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * rotateDirection);
        //Vector3 rotation = new Vector3(0.0f, m_Rotate.y, 0.0f) * _rotateSpeed * Time.deltaTime;
        //m_Rigidbody.rotation = rotation; VECTOR3/QUATERNION ISSUE
    }

    public void PauseUnpause()
    {
            if (!pauseScreen.activeInHierarchy)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
    }
}
