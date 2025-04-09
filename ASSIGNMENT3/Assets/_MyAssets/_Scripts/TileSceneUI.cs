using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TileSceneUI : MonoBehaviour
{
    public AudioClip BackgroundMusic;
    private SoundManager soundManager;
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("TileScene");
    }
    public void TogglePanel()
    {
        MainController.Instance.UIManager.TogglePanel();
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
        soundManager = MainController.Instance.SoundManager;

        if (BackgroundMusic != null)
        {
            soundManager.AddSound("BackgroundMusic", BackgroundMusic, SoundManager.SoundType.SOUND_MUSIC);
            soundManager.PlayMusic("BackgroundMusic");
        }
        masterVolumeSlider.value = 1f;
        sfxVolumeSlider.value = 1f;
        musicVolumeSlider.value = 0.25f;
        soundManager.SetMasterVolume(masterVolumeSlider.value);
        soundManager.SetVolume(sfxVolumeSlider.value, SoundManager.SoundType.SOUND_SFX);
        soundManager.SetVolume(musicVolumeSlider.value, SoundManager.SoundType.SOUND_MUSIC);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
