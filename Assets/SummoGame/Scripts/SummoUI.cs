using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummoUI : MonoBehaviour
{
    public void PresedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRestart()
    {
        SceneManager.LoadScene("SummoGame");
    }

}
