using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_2 : MonoBehaviour
{
    PlayerController controls;
    Vector2 m_Move;
    Vector2 m_Look;
    Rigidbody m_Rigidbody;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float m_Thrust = 20f;

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

    public void OnLook(InputValue value)
    {
        m_Look = value.Get<Vector2>();
    }

    public void OnJump()
    {
        m_Rigidbody.AddForce(0, m_Thrust, 0);
    }

    public void OnSprint()
    {
        moveSpeed += 500f; //this works, but permanently adds the speed
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_Move.x, 0.0f, m_Move.y) * moveSpeed * Time.deltaTime;        
        m_Rigidbody.velocity = movement;

        //mouse look        
        //Vector2 look = new Vector2(m_Look.x, m_Look.y) * Time.deltaTime;
        //m_Rigidbody.rotation = look; //nope
    }
}
