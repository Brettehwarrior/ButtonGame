using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FailMessageGenerator : MonoBehaviour
{
    [SerializeField] private List<string> failMessages;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.text = failMessages[Random.Range(0, failMessages.Count)];
    }
}
