using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public void LoadTitlScene()
    {
        MainController.instance.LoadScene("TitleScene");
    }
    public void LoadGameScene()
    {
        MainController.instance.LoadScene("SampleScene");

    }
    public void LoadGameOverScene()
    {
        MainController.instance.LoadScene("GameOverScene");

    }
}
