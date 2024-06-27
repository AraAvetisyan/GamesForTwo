using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGameMainMenuScript : MonoBehaviour
{
    [SerializeField] private bool isSingle;
    public void PressedChickenGameOne()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameOne");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameOneSingle");
        }
    }
    public void PressedChickenGameTwo()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameTwo");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameTwoSingle");
        }
    }
    public void PressedChickenGameThree()
    {
        if (!isSingle)
        {
            SceneManager.LoadScene("ChickenGameThree");
        }
        else
        {

            SceneManager.LoadScene("ChickenGameThreeSingle");
        }
    }
    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
