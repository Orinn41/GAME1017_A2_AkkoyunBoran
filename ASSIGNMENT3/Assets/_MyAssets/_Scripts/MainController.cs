using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance {  get; private set; }
    public SoundManager SoundManager { get; private set; }
    public UIManager UIManager { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this )
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SoundManager = GetComponentInChildren<SoundManager>();
        UIManager = GetComponentInChildren<UIManager>();
        SoundManager.Initialize(gameObject);
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
