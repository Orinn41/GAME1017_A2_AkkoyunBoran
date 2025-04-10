using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } // Static object of the class.
    [SerializeField] TMP_Text timerText;
    private float startTime;

    private void Awake() // Ensure there is only one instance.
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Will persist between scenes.
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
}
