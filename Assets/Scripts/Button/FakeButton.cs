using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ButtonMeshUpdater))]
public class FakeButton : MonoBehaviour
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
        _meshUpdater = GetComponent<ButtonMeshUpdater>();
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
        
        Debug.Log("Fake Button Pressed.");
        int goneCount = 0;
        gameObject.SetActive(false);

        for (int i = 0; i < 8; i++)
        {
            if (gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                Debug.Log("Round continue");
                break;
            }
            else
            {
                goneCount++;
                if (goneCount == 8)
                {
                    Debug.Log("Round over");
                    break;
                }
            }
        }

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