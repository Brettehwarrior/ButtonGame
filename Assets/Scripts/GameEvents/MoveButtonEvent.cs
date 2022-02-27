using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveButtonEvent : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float duration;
    private Button[] _buttons;
    private Vector2 direction;

    private void Start()
    {
        _buttons = FindObjectsOfType<Button>();
        Invoke("End", duration);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        foreach (var button in _buttons)
        {
            button.GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, 0.1f, direction.y) * force * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void End()
    {
        Destroy(gameObject);
    }
}
