using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesForTwoButtons : MonoBehaviour
{
    
    public void PressedChickenGameButton()
    {
        SceneManager.LoadScene("ChickenGame");
    }

    public void PressedGreenBallButton()
    {
        SceneManager.LoadScene("GreenBall");
    }

    public void PressedTimerGameButton()
    {
        SceneManager.LoadScene("TimerGame");
    }

    public void PressedRedCircleButton()
    {
        SceneManager.LoadScene("RedCircle");
    }

    public void PressedDinosaurGameButton()
    {
        SceneManager.LoadScene("DinosaurGame");
    }

    public void PressedCatPawButton()
    {
        SceneManager.LoadScene("CatPaw");
    }
}