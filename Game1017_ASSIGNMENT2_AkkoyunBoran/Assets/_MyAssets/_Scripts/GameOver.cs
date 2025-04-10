using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        if (Game.Instance != null && timeText != null)
        {
            timeText.text = "Your Time: " + Game.Instance.FinalTime.ToString("F2") + "s";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
