using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioController : MonoBehaviour
{

    public static MainMenuAudioController Instance;
    public GameObject Music;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

}
