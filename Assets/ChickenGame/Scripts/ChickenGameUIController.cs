using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameUIController : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    
    public void PressedHomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedChickenGameOneRestart()
    {
        if (sceneIndex == 1)
        {
            SceneManager.LoadScene("ChickenGameOne");
        }
        if (sceneIndex == 2)
        {
            SceneManager.LoadScene("ChickenGameTwo");
        }
        if(sceneIndex == 3)
        {
            SceneManager.LoadScene("ChickenGameThree");
        }
        if (sceneIndex == 4)
        {
            SceneManager.LoadScene("ChickenGameOneSingle");
        }
        if (sceneIndex == 5)
        {
            SceneManager.LoadScene("ChickenGameTwoSingle");
        }
        if (sceneIndex == 6)
        {
            SceneManager.LoadScene("ChickenGameThreeSingle");
        }
    }
}
