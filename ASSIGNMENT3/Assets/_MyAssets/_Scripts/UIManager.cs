using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (Panel != null)
        {
            Panel.SetActive(false);
        }

    }
    public void TogglePanel()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        if (Panel != null)
        {
            Panel.SetActive(isPaused);
        }
    }
    public void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
