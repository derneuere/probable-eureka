using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {

    public float _speed = 1.0f;
    public float x = 0;
    public float y = 0;

    public bool actionA = false;
    public bool actionB = false;
    public bool actionX = false;
    public bool actionY = false;

    public Country _homeCountry;        // Player's home Country
    public Country _currentCountry;     // Country that the player is currently above
    private Country _lastCountry;     // Country that the player is currently above


    private InputDevice _userDevice;
    private PlayerActions _playerActions;

    private Rigidbody rb;

	// Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void bindGamepad(InputDevice device)
    {
        _userDevice = device;
        _playerActions = new PlayerActions();
        _playerActions.bindToGamepad(device);
    }

    public void bindKeyboard()
    {
        _playerActions = new PlayerActions();
        _playerActions.bindToKeyboard();
    }

    private void FixedUpdate()
    {
        if (_playerActions == null) return;

        float moveHorizontal = _playerActions.Move.X;
        float moveVertical = _playerActions.Move.Y;
        x = moveHorizontal;
        y = moveVertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * _speed);

        // Check actions
        actionA = _playerActions.ActionA.IsPressed;
        actionB = _playerActions.ActionB.IsPressed;
        actionX = _playerActions.ActionX.IsPressed;
        actionY = _playerActions.ActionY.IsPressed;

        updateCurrentCountry();
    }

    private void updateCurrentCountry()
    {
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
    }

    private void onEnteredCountry(Country oldCountry, Country newCountry)
    {
        Debug.Log("Player Entered Country");
    }

    private void onExitedCountry(Country oldCountry)
    {
        Debug.Log("Player Exited Country)");
    }
}
