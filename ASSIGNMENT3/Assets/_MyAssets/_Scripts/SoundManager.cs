using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SoundType
{
    SOUND_SFX,
    SOUND_MUSIC
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider sterioPanningSlider;

    private float sfxVolume = 0.75f;
    private float musicVolume = 0.25f;
    private float masterVolume = 1.0f;
    private float sterioPanning = 0.0f;

    public static SoundManager instance { get; private set; }
    private Dictionary<string, AudioClip> sfxDictionary;
    private Dictionary<string, AudioClip> musicDictionary;
    private AudioSource sfxSource;
    private AudioSource musicSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void Initialize()
    {
        sfxDictionary = new Dictionary<string, AudioClip>();
        musicDictionary = new Dictionary<string, AudioClip>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSource.volume = sfxVolume;
        musicSource.volume = musicVolume;
        AudioListener.volume = masterVolume;
        sfxSource.panStereo = sterioPanning;
        musicSource.panStereo = sterioPanning;
        if (sfxSlider) sfxSlider.value = sfxVolume;
        if (musicSlider) musicSlider.value = musicVolume;
        if (masterVolumeSlider) masterVolumeSlider.value = masterVolume;
        if (sterioPanningSlider) sterioPanningSlider.value = sterioPanning;

        if (sfxSlider) sfxSlider.onValueChanged.AddListener(SetVolumeSFX);
        if (musicSlider) musicSlider.onValueChanged.AddListener(SetVolumeMusic);
        if (masterVolumeSlider) masterVolumeSlider.onValueChanged.AddListener(SetVolumeMaster);
        if (sterioPanningSlider) sterioPanningSlider.onValueChanged.AddListener(SetSterioPanning);
    }

    public void SetVolumeSFX(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume * masterVolume;
    }
    public void SetVolumeMusic(float volume)
    {
        musicVolume = volume;
        musicSource.volume = musicVolume * masterVolume;
    }
    public void SetVolumeMaster(float volume)
    {
        masterVolume = volume;
        sfxSource.volume = sfxVolume * masterVolume;
        musicSource.volume = musicVolume * masterVolume;
        AudioListener.volume = masterVolume;
    }
    public void SetSterioPanning(float panning)
    {
        sterioPanning = panning;
        sfxSource.panStereo = sterioPanning;
        musicSource.panStereo = sterioPanning;
    }
    public float GetSFXVolume()
    {
        return sfxVolume;
    }
    public float GetMusicVolume()
    {
        return musicVolume;
    }
    public float GetMasterVolume()
    {
        return masterVolume;
    }
    public float GetSterioPanning()
    {
        return sterioPanning;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
