using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_2 : MonoBehaviour
{
    PlayerController controls;
    Vector2 move;
    Vector2 mouseInput;

    [SerializeField] float moveSpeed = 10f;

    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
        //mouse look
        //controls.Player.Look.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        //controls.Player.Look.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        //mouse look        
        //Vector2 look = new Vector2(mouseInput.x, mouseInput.y);
    }
}
