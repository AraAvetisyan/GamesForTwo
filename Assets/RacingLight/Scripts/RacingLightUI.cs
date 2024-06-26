using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingLightUI : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("RacingLight");
        }
        if (isSingle)
        {
            SceneManager.LoadScene("RacingLightSingle");
        }
    }
}
