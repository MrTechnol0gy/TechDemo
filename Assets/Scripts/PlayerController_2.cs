using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_2 : MonoBehaviour
{
    PlayerController controls;
    Vector2 m_Move;
    Vector2 m_Look;

    [SerializeField] float moveSpeed = 10f;

    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Move.performed += ctx => m_Move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => m_Move = Vector2.zero;
        //mouse look
        //controls.Player.Look.performed += ctx => m_Look.x = ctx.ReadValue<float>();
        //controls.Player.Look.performed += ctx => m_Look.y = ctx.ReadValue<float>();
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

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_Move.x, 0.0f, m_Move.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        //mouse look        
        Vector2 look = new Vector2(m_Look.x, m_Look.y) * Time.deltaTime;
        transform.Rotate(look, Space.World); //so close, but so wrong - should this be on the camera instead?
        //transform.localRotation = look;
    }
}
