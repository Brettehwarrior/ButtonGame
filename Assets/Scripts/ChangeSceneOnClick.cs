using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
