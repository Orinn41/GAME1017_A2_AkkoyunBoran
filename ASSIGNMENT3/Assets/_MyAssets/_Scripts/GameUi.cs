using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameUi : MonoBehaviour
{
    private UIManager uiManager;
    public AudioClip BackgroundMusic;
    private SoundManager soundManager;
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public GameObject pausePanel;
    public Button pauseButton;
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}
    //public void RestartGame()
    //{
    //    SceneManager.LoadScene("TileScene");
    //}
    public void TogglePausePanel()
    {
        bool isActive = pausePanel.activeSelf;
        pausePanel.SetActive(!isActive);
        if (isActive)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        uiManager.TogglePanel();
    }


    public void MasterVolume(float value)
    {
        MainController.Instance.SoundManager.SetMasterVolume(value);
    }

    public void SFXVolume(float value)
    {
        MainController.Instance.SoundManager.SetVolume(value, SoundManager.SoundType.SOUND_SFX);
    }

    public void MusicVolume(float value)
    {
        MainController.Instance.SoundManager.SetVolume(value, SoundManager.SoundType.SOUND_MUSIC);
    }


    // Start is called before the first frame update
    void Start()
    {
        uiManager = MainController.Instance.UIManager;
        Debug.Log("Game Scene UI Initialized.");
        masterVolumeSlider.value = 1f;
        sfxVolumeSlider.value = 1f;
        musicVolumeSlider.value = 0.25f;
        MainController.Instance.SoundManager.SetMasterVolume(masterVolumeSlider.value);
        MainController.Instance.SoundManager.SetVolume(sfxVolumeSlider.value, SoundManager.SoundType.SOUND_SFX);
        MainController.Instance.SoundManager.SetVolume(musicVolumeSlider.value, SoundManager.SoundType.SOUND_MUSIC);
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(TogglePausePanel);

    }
    public void CustomPause()
    {
        uiManager.TogglePanel(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
