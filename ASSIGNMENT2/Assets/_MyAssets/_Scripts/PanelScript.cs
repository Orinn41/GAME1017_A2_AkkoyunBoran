using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PanelScript : MonoBehaviour
{
    public GameObject panel;
    public Button restartButton;
    public Slider sfxSlider;
    public Slider musicSlider;
    public Slider masterVolumeSlider;
    public Slider sterioPanningSlider;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

        sfxSlider.onValueChanged.AddListener(SoundManager.instance.SetVolumeSFX);
        musicSlider.onValueChanged.AddListener(SoundManager.instance.SetVolumeMusic);
        masterVolumeSlider.onValueChanged.AddListener(SoundManager.instance.SetVolumeMaster);
        sterioPanningSlider.onValueChanged.AddListener(SoundManager.instance.SetSterioPanning);
        sfxSlider.value = SoundManager.instance.GetSFXVolume();
        musicSlider.value = SoundManager.instance.GetMusicVolume();
        masterVolumeSlider.value = SoundManager.instance.GetMasterVolume();
        sterioPanningSlider.value = SoundManager.instance.GetSterioPanning();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        isPaused = true;
    }
    void ContinueGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        isPaused = false;
    }
    void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TileScene");
    }
}
