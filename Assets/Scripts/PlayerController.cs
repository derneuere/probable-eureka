using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {

    public float _speed = 1.0f;

    public Vector2 input;
    
    public bool actionA = false;
    public bool actionB = false;
    public bool actionX = false;
    public bool actionY = false;

    public Transform View;

    private float cooldown;
    
    private InputDevice _userDevice;
    public PlayerActions PlayerActions;

    private Rigidbody2D _rb;

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

        var moveHorizontal = PlayerActions.Move.X;
        var moveVertical = PlayerActions.Move.Y;

        var x = moveHorizontal;
        var y = moveVertical;

        input = new Vector2(x, y);
        
        Vector3 movement = new Vector2(moveHorizontal, moveVertical);
        
        _rb.AddForce(movement * _speed * Oscillator());

        // Check actions
        actionA = PlayerActions.ActionA.WasPressed;
        actionB = PlayerActions.ActionB.WasPressed;
        actionX = PlayerActions.ActionX.WasPressed;
        actionY = PlayerActions.ActionY.WasPressed;

        //Dash:
        if (actionA)
        {
            if (Time.time - cooldown > 3.0f)
            {
                cooldown = Time.time;
                _rb.AddForce(View.transform.up* 3.0f, ForceMode2D.Impulse);                
            }
        }
        
        //Does this work?
        if (movement.magnitude > 0.1f)
        {
            View.transform.up = Filter.FIR3(View.transform.up, movement).normalized;            
        }
        else
        {
            View.transform.up = Filter.FIR3(View.transform.up, Vector2.up, 0.95f).normalized;                        
        }
    }

    private float Oscillator()
    {
        return 0.7f + Mathf.Sin(Time.time * 2.0f * 2.0f * Mathf.PI);
    }

    private void updateCurrentCountry()
    {
        /*
        _currentCountry = null;

        var layerMask = LayerMask.GetMask("Countries");


        RaycastHit hit;
        // Does the ray intersect any country object
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            _currentCountry = hit.transform.GetComponent<Country>();

            if (_currentCountry != _lastCountry)
            {
                if (_lastCountry != null) onExitedCountry(_lastCountry);

                if (_currentCountry != null) onEnteredCountry(_lastCountry, _currentCountry);

                _lastCountry = _currentCountry;
            }
        }
        else
        {
            _currentCountry = null;
            if (_lastCountry != null)
            {
                onExitedCountry(_lastCountry);
                _lastCountry = null;
            }
        }
        */
    }

}
