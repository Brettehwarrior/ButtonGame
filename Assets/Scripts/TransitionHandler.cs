using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    [System.Serializable]
    private struct TransitionAction
    {
        public GameObject gameObject;
        public float delay;
    }
    
    [SerializeField] private List<TransitionAction> _startTransition;
    private int _startTransitionIndex;

    private Coroutine _coroutine = null;
    private Queue<GameObject> _toHide = new Queue<GameObject>();

    private void Start()
    {
        _startTransitionIndex = 0;
    }

    private void Update()
    {
        if (_coroutine != null && _startTransitionIndex < _startTransition.Count)
            return;
            
        _coroutine = StartCoroutine(Reveal(_startTransition[_startTransitionIndex]));
        _startTransitionIndex++;
    }

    private IEnumerator Reveal(TransitionAction action)
    {
        if (action.gameObject != null)
        {
            action.gameObject.SetActive(true);
            _toHide.Enqueue(action.gameObject);
        }
        
        yield return new WaitForSeconds(action.delay);

        // Negative delay means hide everything
        if (action.delay < 0)
        {
            while (_toHide.Count > 0)
            {
                _toHide.Dequeue().SetActive(false);
            }
        }

        _coroutine = null;
    }
}
