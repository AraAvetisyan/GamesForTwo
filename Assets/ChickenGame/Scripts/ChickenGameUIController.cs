using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameUIController : MonoBehaviour
{
    public void PressedHomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedChickenGameOneRestart()
    {
        SceneManager.LoadScene("ChickenGameOne");
    }
}
