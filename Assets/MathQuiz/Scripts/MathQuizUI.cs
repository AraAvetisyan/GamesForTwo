using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathQuizUI : MonoBehaviour
{

    [SerializeField] private bool isSingle;

    public void PressedHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedRest()
    {
        if (isSingle)
        {
            SceneManager.LoadScene("MathQuizSingle");
        }
        else
        {
            SceneManager.LoadScene("MathQuiz");
        }
    }

}