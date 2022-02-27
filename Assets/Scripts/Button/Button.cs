using System;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent buttonPressEvent = new UnityEvent();
    public UnityEvent buttonReleaseEvent = new UnityEvent();
    
    private ButtonMeshUpdater _meshUpdater;
    
    protected enum PressState
    {
        NotPressed, // Initial state
        Held,       // Button is held (doom)
        Triggered   // Button has been released (full press action)
    }

    protected PressState state;

    
    
    private void Start()
    {
        state = PressState.NotPressed;
        _meshUpdater = GetComponentInChildren<ButtonMeshUpdater>();
    }

    private void Hold()
    {
        state = PressState.Held;
        _meshUpdater.Hold();
        buttonPressEvent.Invoke();
    }

    private void Trigger()
    {
        state = PressState.Triggered;
        _meshUpdater.Release();
        buttonReleaseEvent.Invoke();
    }
    
    // TODO: Maybe make it press while dragging mouse across as well?
    private void OnMouseDown()
    {
        Hold();
    }

    private void OnMouseExit()
    {
        if (state == PressState.Held)
        {
            Trigger();
        }
    }

    private void OnMouseUpAsButton()
    {
        if (state == PressState.Held)
        {
            Trigger();
        }
    }
}
