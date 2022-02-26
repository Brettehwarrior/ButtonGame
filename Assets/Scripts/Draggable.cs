using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float height = 0.2f;
        [Range(0.01f, 5f)] [SerializeField] private float speed = 2f;

        private float _restHeight;
        private bool _dragging;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _restHeight = transform.position.y; // Assumes spawning on table surface (probably not true)
            _dragging = false;
        }

        private void Update()
        {
            if (_dragging)
            {
                Vector3 mouseVector = Input.mousePosition;
                mouseVector.z = _restHeight;
                Vector3 target = _camera.ScreenToWorldPoint(mouseVector);
                target.y = _restHeight + height;
                Debug.Log(target);
                
                // Move towards point
                Transform cachedTransform = transform;
                cachedTransform.Translate((target - cachedTransform.position) / speed);
                
                // 
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