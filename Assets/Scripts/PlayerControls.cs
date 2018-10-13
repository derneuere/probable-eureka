using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InControl;
using TMPro;

public class PlayerControls : MonoBehaviour {

    public List<PlayerController> _unassignedPlayers;
    private List<PlayerController> _assignedPlayers = new List<PlayerController>();
    private bool hasBoundKeyboard = false; 

    private List<InputDevice> _unassignedDevices = new List<InputDevice>();
    private List<InputDevice> _assignedDevices = new List<InputDevice>();


    // Use this for initialization
    private void Start ()
    {
        if (_unassignedPlayers.Count == 0)
        {
            _unassignedPlayers = new List<PlayerController>(FindObjectsOfType<PlayerController>());
        }
        
        for(var i=0; i < InputManager.Devices.Count; i++)
        {
            _unassignedDevices.Add(InputManager.Devices[i]);
        }
	}
	
	// Update is called once per frame
    private void Update () {

        if (_unassignedPlayers == null || (_unassignedDevices == null && hasBoundKeyboard)) return;
        if (_unassignedPlayers.Count == 0 || (_unassignedDevices.Count == 0 && hasBoundKeyboard)) return;

        // Check Keyboard
        if (!hasBoundKeyboard)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Assign to the next player
                PlayerController nextPlayer = _unassignedPlayers[0];
                nextPlayer.bindKeyboard();
                _unassignedPlayers.RemoveAt(0);
                _assignedPlayers.Add(nextPlayer);
                nextPlayer.gameObject.SetActive(true);

                hasBoundKeyboard = true;
            }
        }

        // Check Gamepad
        InputDevice activeDevice = InputManager.ActiveDevice;
        InputControl startButton = activeDevice.GetControl(InputControlType.Start);
        InputControl menuButton = activeDevice.GetControl(InputControlType.Menu);
        if (startButton.WasPressed || menuButton.WasPressed)
        {
            if (_unassignedDevices.Contains(activeDevice))
            {
                // Assign to the next player
                _unassignedDevices.Remove(activeDevice);
                _assignedDevices.Add(activeDevice);

                PlayerController nextPlayer = _unassignedPlayers[0];
                nextPlayer.bindGamepad(activeDevice);
                _unassignedPlayers.RemoveAt(0);
                _assignedPlayers.Add(nextPlayer);
                nextPlayer.gameObject.SetActive(true);

            }
        }


	}
}
