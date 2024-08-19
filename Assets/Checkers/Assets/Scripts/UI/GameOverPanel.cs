using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject Board;
    public TextMeshProUGUI WinnerText;
    public GameAudio GameAudio;

    private Animator gameOverPanelAnimator;
    [SerializeField] private GameObject blueWinner, redWinner;
    [SerializeField] private AudioSource end;
    private void Awake()
    {
        gameOverPanelAnimator = GetComponent<Animator>();
    }

    public void SetWinnerText(int winner)
    {
        //WinnerText.text = winnerPawnColor.ToString().ToUpper() + " WINS";
        if (winner == 0)
        {
            GameAudio.GameMusic.volume = 0;
            end.Play();
            redWinner.SetActive(true);
            if (Geekplay.Instance.language == "ru")
            {
                WinnerText.text = "Красные Победили";
            }
            if (Geekplay.Instance.language == "en")
            {
                WinnerText.text = "Reds Won";
            }
            if (Geekplay.Instance.language == "tr")
            {
                WinnerText.text = "Kırmızılar Kazandı";
            }
        }
        if (winner == 1)
        {
            end.Play();
            blueWinner.SetActive(true);
            if(Geekplay.Instance.language == "ru")
            {
                WinnerText.text = "Синие Победили";
            }
            if (Geekplay.Instance.language == "en")
            {
                WinnerText.text = "Blues Won";
            }
            if (Geekplay.Instance.language == "tr")
            {
                WinnerText.text = "Maviler kazandı";
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