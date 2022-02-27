using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Swatter : MonoBehaviour
{
    /* code by MR. BAKER< I AM NOT A PRO > HE IS */
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float maxHeight = 0.6f;
    [SerializeField] private float swatHeight = 0.2f;
    
    private float _height;
    private bool _following;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _following = false;
    }

    void Update()
    {
        if(_following && Input.GetMouseButton(1))
        {
            _height = swatHeight;
        } else
        {
            _height = maxHeight;
        }
    }

    private void FixedUpdate()
    {
        if (_following)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask);
            Vector3 target = hit.point;

            if (target != Vector3.zero)
            {
                target.y += _height;

                // Snap to point
                transform.position = target;
                transform.eulerAngles = Vector3.zero;
            }

            // Reset rigidbody if present
            if (_rigidbody != null)
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }
    
    /*Heres my puny code*/
    void OnMouseDown()
    {
        _following = !_following;
    }
}
