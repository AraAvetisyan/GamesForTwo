using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummoUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PresedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestart()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("SummoGame");
        }
        else
        {
            SceneManager.LoadScene("SummoGameSingle");
        }
    }

}
