using System;
using UnityEngine;
using UnityEngine.Events;

public class FakeButton : Button
{
    private void Trigger()
    {
        state = PressState.Triggered;
        
        Debug.Log("Fake Button Pressed.");
        int goneCount = 0;
        gameObject.SetActive(false);

        for (int i = 0; i < 8; i++)
        {
            if (gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                Debug.Log("Round continue");
                break;
            }
            else
            {
                goneCount++;
                if (goneCount == 8)
                {
                    Debug.Log("Round over");
                    break;
                }
            }
        }
    }
}