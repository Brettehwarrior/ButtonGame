using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve difficultyCurve;
    [SerializeField] private float timeToMaxDifficulty;
    [SerializeField] private float maxTimeBetweenEvents;
    [SerializeField] private float randomTimeOffset;

    [SerializeField] private List<GameObject> eventObjects;

    private Coroutine _nextEventCoroutine;
    private float _startTime;

    private void Start()
    {
        _startTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (_nextEventCoroutine != null)
            return;
        
        float timeToNextEvent = difficultyCurve.Evaluate((Time.realtimeSinceStartup - _startTime) / timeToMaxDifficulty) * maxTimeBetweenEvents;

        _nextEventCoroutine = StartCoroutine(StartEventAndWait(timeToNextEvent));
    }

    private IEnumerator StartEventAndWait(float time)
    {
        float offset = Random.Range(-randomTimeOffset, randomTimeOffset);
        if (offset < 0)
            offset = 0;
        
        yield return new WaitForSeconds(time + offset);
        
        // True Random event (not weighted)
        Instantiate(eventObjects[Random.Range(0, eventObjects.Count)]);

        _nextEventCoroutine = null;
    }
}
