using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour
{

    public const float Speed = 12.0f;
    public const float Jump = 8.0f;
    public const float FallFactor = 2.0f;

    public Transform View;

    private float cooldown;

    private InputDevice _userDevice;
    public PlayerActions PlayerActions;

    private Rigidbody2D _rb;
    private bool grounded = true;


    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void bindGamepad(InputDevice device)
    {
        _userDevice = device;
        PlayerActions = new PlayerActions();
        PlayerActions.bindToGamepad(device);
    }

    public void bindKeyboard()
    {
        PlayerActions = new PlayerActions();
        PlayerActions.bindToKeyboard();
    }

    private void FixedUpdate()
    {
        if (PlayerActions == null) return;

        //Apply movement
        var input = new Vector2(PlayerActions.Move.X, 0);
        _rb.AddForce(input * Speed);

        //Jump
        if (PlayerActions.ActionA.WasPressed)
        {
            if (grounded)
            {
                grounded = false;
                _rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            }
        }

        //Jumping up is softer than falling down.
        _rb.gravityScale = _rb.velocity.y > 0 ? 1 : FallFactor;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If we hit something that is reasonably straight below us, we can jump again.
        var direction = (Vector2) transform.position - other.contacts[0].point;
        if (Vector2.Dot(direction, Vector2.up) > 0.5)
        {
            grounded = true;
        }
    }

}