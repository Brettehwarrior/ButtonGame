using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string failSceneName;
    [SerializeField] private float failSceneTransitionDelay = 0.2f;
    [SerializeField] private List<Button> failButtons = new List<Button>();
    
    private void Start()
    {
        foreach (var button in failButtons)
        {
            Subscribe(button);
        }
    }

    public void AddFailButton(Button button)
    {
        failButtons.Add(button);
        Subscribe(button);
    }

    private void Subscribe(Button button)
    {
        button.buttonPressEvent.AddListener(BeginFail);
        button.buttonReleaseEvent.AddListener(Fail);
    }

    /// <summary>
    /// Button was pressed, cut music and stop counting time
    /// </summary>
    private void BeginFail()
    {
        Debug.Log("You are already fail");
    }
    
    /// <summary>
    /// Button released, end the game
    /// </summary>
    private void Fail()
    {
        Debug.Log("Nani?");
        StartCoroutine(GoToFailScene());
    }

    private IEnumerator GoToFailScene()
    {
        yield return new WaitForSecondsRealtime(failSceneTransitionDelay);
        SceneManager.LoadScene(failSceneName);
    }
}
