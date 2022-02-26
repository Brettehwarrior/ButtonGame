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

    private float startTime;
    private Coroutine _nextEventCoroutine;

    private void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (_nextEventCoroutine != null)
            return;
        
        float timeToNextEvent = difficultyCurve.Evaluate((Time.realtimeSinceStartup - startTime) / timeToMaxDifficulty) * maxTimeBetweenEvents;

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
