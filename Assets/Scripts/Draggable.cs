using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float height = 0.15f;
        [SerializeField] private float throwForceScale = 10f;

        private bool _dragging;
        private Vector3 _prevTargetPos;
        private Vector3 _motion;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
                    target.y += height;
                    
                    // Snap to point
                    transform.position = target;
                    transform.eulerAngles = Vector3.zero;
                }

                // Reset rigidbody if present
                if (_rigidbody != null)
                {
                    _rigidbody.velocity = Vector3.zero;
                }

                _motion = target - _prevTargetPos;
                _prevTargetPos = target;
            }
        }

        private void OnMouseDown()
        {
            _dragging = true;
        }

        private void OnMouseUp()
        {
            _dragging = false;

            if (_rigidbody != null)
            {
                Debug.Log(_motion);
                _rigidbody.AddForce(_motion * throwForceScale, ForceMode.Impulse);
            }
        }
    }
}