using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerActions : PlayerActionSet
{
    public PlayerAction Start;

    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;

    public PlayerAction ActionA;
    public PlayerAction ActionB;
    public PlayerAction ActionX;
    public PlayerAction ActionY;

    public PlayerTwoAxisAction Move;

    public PlayerActions()
    {
        Start = CreatePlayerAction("Start");

        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");

        ActionA = CreatePlayerAction("Action A");
        ActionB = CreatePlayerAction("Action B");
        ActionX = CreatePlayerAction("Action X");
        ActionY = CreatePlayerAction("Action Y");

        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }

    public void bindToGamepad(InputDevice device)
    {
        Device = device;

        Start.AddDefaultBinding(InputControlType.Start);

        Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        Right.AddDefaultBinding(InputControlType.LeftStickRight);
        Up.AddDefaultBinding(InputControlType.LeftStickUp);
        Down.AddDefaultBinding(InputControlType.LeftStickDown);

        /*
        Left.AddDefaultBinding(InputControlType.DPadLeft);
        Right.AddDefaultBinding(InputControlType.DPadRight);
        Up.AddDefaultBinding(InputControlType.DPadUp);
        Down.AddDefaultBinding(InputControlType.DPadDown);
        */

        ActionA.AddDefaultBinding(InputControlType.Action1);
        ActionB.AddDefaultBinding(InputControlType.Action2);
        ActionX.AddDefaultBinding(InputControlType.Action3);
        ActionY.AddDefaultBinding(InputControlType.Action4);
    }

    public void bindToKeyboard()
    {
        Start.AddDefaultBinding(Key.Space);

        // WASD movement
        Left.AddDefaultBinding(Key.A);
        Right.AddDefaultBinding(Key.D);
        Up.AddDefaultBinding(Key.W);
        Down.AddDefaultBinding(Key.S);

        // Arrow keys mirror positions of gamepad ABXY buttons
        ActionA.AddDefaultBinding(Key.DownArrow);
        ActionB.AddDefaultBinding(Key.RightArrow);
        ActionX.AddDefaultBinding(Key.LeftArrow);
        ActionY.AddDefaultBinding(Key.UpArrow);
    }
}