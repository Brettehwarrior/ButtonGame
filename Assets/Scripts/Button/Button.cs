using System;
using UnityEngine;

[RequireComponent(typeof(ButtonMeshUpdater))]
public class Button : MonoBehaviour
{
    private ButtonMeshUpdater _meshUpdater;
    
    private enum PressState
    {
        NotPressed, // Initial state
        Held,       // Button is held (doom)
        Triggered   // Button has been released (full press action)
    }

    private PressState _state;

    private void Start()
    {
        _state = PressState.NotPressed;
        _meshUpdater = GetComponent<ButtonMeshUpdater>();
    }

    private void Hold()
    {
        _state = PressState.Held;
        _meshUpdater.Hold();
    }

    private void Trigger()
    {
        _meshUpdater.Release();
        _state = PressState.Triggered;
        Debug.Log("You fool, the button has been pressed.");
    }
    
    // TODO: Maybe make it press while dragging mouse across as well?
    private void OnMouseDown()
    {
        Hold();
    }

    private void OnMouseExit()
    {
        if (_state == PressState.Held)
        {
            Trigger();
        }
    }

    private void OnMouseUpAsButton()
    {
        if (_state == PressState.Held)
        {
            Trigger();
        }
    }
}
