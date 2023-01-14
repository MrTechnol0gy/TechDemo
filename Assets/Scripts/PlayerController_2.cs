using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_2 : MonoBehaviour
{
    PlayerController controls;
    Vector2 move;

    [SerializeField] float moveSpeed = 10f;

    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void SendMessage()
    {
        //Debug.Log("Button Pressed.");
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
    }
}
