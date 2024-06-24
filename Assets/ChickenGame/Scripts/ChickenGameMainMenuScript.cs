using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameMainMenuScript : MonoBehaviour
{

    public void PressedChickenGameOne()
    {
        SceneManager.LoadScene("ChickenGameOne");
    }
    public void PressedChickenGameTwo()
    {
        SceneManager.LoadScene("ChickenGameTwo");
    }
    public void PressedChickenGameThree()
    {
        SceneManager.LoadScene("ChickenGameThree");
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
