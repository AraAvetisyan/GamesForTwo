using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingLightUI : MonoBehaviour
{
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        SceneManager.LoadScene("RacingLight");
    }
}
