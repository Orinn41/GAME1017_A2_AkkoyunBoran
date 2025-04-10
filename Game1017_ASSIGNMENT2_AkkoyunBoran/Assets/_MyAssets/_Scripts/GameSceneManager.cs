using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Button gameStartButton;
    // Start is called before the first frame update
    void Start()
    {
        if (gameStartButton != null)
        {
            gameStartButton.onClick.AddListener(gameStartClick);
        }
    }
    public void gameStartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
