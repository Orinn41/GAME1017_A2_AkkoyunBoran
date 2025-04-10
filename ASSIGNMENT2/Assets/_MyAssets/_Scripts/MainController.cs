using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController instance;
    public SoundManager soundManager;
    public UiManager uiManager;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (soundManager == null)
        {
            soundManager = GetComponentInChildren<SoundManager>();
        }
        if (uiManager == null)
        {
            uiManager = GetComponentInChildren<UiManager>();
        }
    }
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


}
