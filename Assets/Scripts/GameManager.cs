using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private string failSceneName;
    [SerializeField] private float failSceneTransitionDelay = 0.2f;
    [SerializeField] private List<Button> failButtons = new List<Button>();
    [SerializeField] private AudioClip mainMusic;
    
    private AudioSource _audioSource;
    private Timer _timer;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneSwitch;
        
        _timer = GetComponent<Timer>();
        _timer.StartTimer();
        
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = mainMusic;
        _audioSource.loop = true;
        _audioSource.Play();
        
        foreach (var button in failButtons)
        {
            Subscribe(button);
        }
    }

    private void OnSceneSwitch(Scene scene, LoadSceneMode _)
    {
        switch (scene.name)
        {
            case "StartScene":
                Destroy(gameObject);
                SceneManager.sceneLoaded -= OnSceneSwitch;
                break;
            case "FailScene":
                GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text += _timer.GetTimeString();
                break;
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
        _timer.StopTimer();
        _audioSource.Stop();
    }
    
    /// <summary>
    /// Button released, end the game
    /// </summary>
    private void Fail()
    {
        StartCoroutine(GoToFailScene());
    }

    private IEnumerator GoToFailScene()
    {
        yield return new WaitForSecondsRealtime(failSceneTransitionDelay);
        SceneManager.LoadScene(failSceneName);
        failButtons.Clear();
    }
    
    
}
