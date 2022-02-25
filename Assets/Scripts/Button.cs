using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    private enum PressState
    {
        NOT_PRESSED,
        HELD,
        TRIGGERED
    }

    private PressState state;

    private void Start()
    {
        state = PressState.NOT_PRESSED;
    }

    private void Trigger()
    {
        state = PressState.TRIGGERED;
        Debug.Log("You fool, the button has been pressed.");
    }
    
    private void OnMouseDown()
    {
        state = PressState.HELD;
    }

    private void OnMouseExit()
    {
        if (state == PressState.HELD)
        {
            Trigger();
        }
    }

    private void OnMouseUpAsButton()
    {
        if (state == PressState.HELD)
        {
            Trigger();
        }
    }
}
