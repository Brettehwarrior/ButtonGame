using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float height = 0.1f;

        private float _restHeight;
        private bool _dragging;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _restHeight = transform.position.y; // Assumes spawning on table surface (probably not true)
            _dragging = false;
        }

        private void FixedUpdate()
        {
            if (_dragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask);
                Vector3 target = hit.point;
                
                if (target != Vector3.zero)
                {
                    target.y = _restHeight + height;
                    
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

        private void OnMouseDown()
        {
            _dragging = true;
        }

        private void OnMouseUp()
        {
            _dragging = false;
        }
    }
}