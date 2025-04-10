using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } // Static object of the class.
    public float FinalTime {  get; private set; }
    [SerializeField] TMP_Text timerText;
    private float startTime;

    private void Awake() // Ensure there is only one instance.
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Will persist between scenes.
            SceneManager.sceneLoaded += OnSceneLoaded;
            Initialize();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances.
        }
    }

    private void Initialize()
    {
      
        // TODO: Load the new music track.
        // TODO: Play the new music track.
        //SOMA.PlayMusic("cyberpunk-street");
        startTime = Time.time;
        StartCoroutine("UpdateTimer");
    }
    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            float elapsedTime = Time.time - startTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s";
            yield return null;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            timerText = GameObject.FindWithTag("TimerText")?.GetComponent<TMP_Text>();

            if (timerText != null)
            {
                startTime = Time.time;
                StopCoroutine("UpdateTimer");
                StartCoroutine("UpdateTimer");
            }
        }
    }
    public void SetFinalTime()
    {
        FinalTime = Time.time - startTime;
    }
}
