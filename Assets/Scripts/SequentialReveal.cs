using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SequentialReveal : MonoBehaviour
{
    [System.Serializable]
    private struct RevealAction
    {
        public GameObject gameObject;
        public float delay;
    }
    
    [SerializeField] private List<RevealAction> _actions;
    private int _startTransitionIndex;

    private Coroutine _coroutine = null;
    private Queue<GameObject> _toHide = new Queue<GameObject>();

    private void Start()
    {
        _startTransitionIndex = 0;
    }

    private void Update()
    {        
        if (_coroutine != null)
            return;

        if (_startTransitionIndex >= _actions.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        
        _coroutine = StartCoroutine(Reveal(_actions[_startTransitionIndex]));
        _startTransitionIndex++;
    }

    private IEnumerator Reveal(RevealAction action)
    {
        if (action.gameObject != null)
        {
            action.gameObject.SetActive(true);
            _toHide.Enqueue(action.gameObject);
        }
        
        yield return new WaitForSeconds(action.delay);

        _coroutine = null;
    }
}
