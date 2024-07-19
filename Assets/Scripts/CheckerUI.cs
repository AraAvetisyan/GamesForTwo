using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckerUI : MonoBehaviour
{
    public void PressedHomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
