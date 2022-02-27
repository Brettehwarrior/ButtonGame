using System;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private float speedTriggerThreshold = 0.2f;

    [SerializeField] private AudioClip pressSound;
    [SerializeField] private AudioClip releaseSound;
    
    public UnityEvent buttonPressEvent = new UnityEvent();
    public UnityEvent buttonReleaseEvent = new UnityEvent();

    private AudioSource _audioSource;
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
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.y < 0.1f)
        {
            // Trigger if fell on ground
            Hold();
            Trigger();
        }
    }

    private void Hold()
    {
        state = PressState.Held;
        _meshUpdater.Hold();
        buttonPressEvent.Invoke();
        _audioSource.PlayOneShot(pressSound);
    }

    private void Trigger()
    {
        if (state != PressState.Held)
            return;

        state = PressState.Triggered;
        _meshUpdater.Release();
        buttonReleaseEvent.Invoke();
        _audioSource.PlayOneShot(releaseSound);
    }
    
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
            Hold();
    }

    private void OnMouseDown()
    {
        Hold();
    }

    private void OnMouseExit()
    {
        Trigger();
    }

    private void OnMouseUpAsButton()
    {
        Trigger();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > speedTriggerThreshold)
            Hold();
    }

    private void OnCollisionExit(Collision other)
    {
        Trigger();
    }
}
