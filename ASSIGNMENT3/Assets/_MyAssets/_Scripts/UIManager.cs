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
        if(Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    public void TogglePanel()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 10f;
        Panel.SetActive(isPaused);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
