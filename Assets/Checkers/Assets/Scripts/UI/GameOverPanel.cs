using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject Board;
    public TextMeshProUGUI WinnerText;
    public GameAudio GameAudio;

    private Animator gameOverPanelAnimator;

    private void Awake()
    {
        gameOverPanelAnimator = GetComponent<Animator>();
    }

    public void SetWinnerText(int winner)
    {
        //WinnerText.text = winnerPawnColor.ToString().ToUpper() + " WINS";
        if (winner == 0)
        {
            if (Geekplay.Instance.language == "ru")
            {
                WinnerText.text = "Черные Победили";
            }
            if (Geekplay.Instance.language == "en")
            {
                WinnerText.text = "Black Wins";
            }
            if (Geekplay.Instance.language == "tr")
            {
                WinnerText.text = "siyah kazanır";
            }
        }
        if (winner == 1)
        {
            if(Geekplay.Instance.language == "ru")
            {
                WinnerText.text = "Белые Победили";
            }
            if (Geekplay.Instance.language == "en")
            {
                WinnerText.text = "White Wins";
            }
            if (Geekplay.Instance.language == "tr")
            {
                WinnerText.text = "beyaz kazanır";
            }
        }
    }

    public void DisableBoard()
    {
        Board.SetActive(false);
    }

    public void ReturnToMenu()
    {
        gameOverPanelAnimator.SetTrigger("ReturnToMenu");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void FadeGameMusic()
    {
        GameAudio.FadeGameMusic();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}