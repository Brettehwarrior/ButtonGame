using System;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent ButtonPressEvent { private set; get; }
    
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
        _meshUpdater = GetComponentInChildren<ButtonMeshUpdater>();
        ButtonPressEvent = new UnityEvent();
    }

    private void Hold()
    {
        _state = PressState.Held;
        _meshUpdater.Hold();
    }

    private void Trigger()
    {
        _state = PressState.Triggered;
        _meshUpdater.Release();
        ButtonPressEvent.Invoke();
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
