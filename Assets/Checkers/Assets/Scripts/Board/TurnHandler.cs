using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnHandler : MonoBehaviour
{
    public PawnColor StartingPawnColor;
    public TurnTextChanger TurnTextChanger;
    public GameOverPanel GameOverPanel;

    private PawnColor turn;
    private int turnInt;
    private int whitePawnCount;
    private int blackPawnCount;
    private bool isGameVsCPU;
    private CPUPlayer cpuPlayer;

    private void Awake()
    {
        turn = StartingPawnColor;
        isGameVsCPU = PlayerPrefs.GetInt("VsCPU") == 1;
    }

    private void Start()
    {
        int boardSize = GetComponent<ITilesGenerator>().BoardSize;
        int pawnRows = GetComponent<PawnsGenerator>().PawnRows;
        whitePawnCount = blackPawnCount = Mathf.CeilToInt(boardSize * pawnRows / 2f);
        cpuPlayer = GetComponent<CPUPlayer>();
    }

    public void NextTurn()
    {
        turn = turn == PawnColor.White ? PawnColor.Black : PawnColor.White;
        if( turn == PawnColor.Black )
        {
            turnInt = 0;
        }else if( turn == PawnColor.White )
        {
            turnInt = 1;
        }
        TurnTextChanger.ChangeTurnText(turnInt);
        if (isGameVsCPU && turn == PawnColor.Black)
            cpuPlayer.DoCPUMove();
    }

    public PawnColor GetTurn()
    {
        return turn;
    }

    public void DecrementPawnCount(GameObject pawn)
    {
        var pawnColor = pawn.GetComponent<IPawnProperties>().PawnColor;
        if (pawnColor == PawnColor.White)
            --whitePawnCount;
        else
            --blackPawnCount;
        CheckVictory();
    }

    private void CheckVictory()
    {
        if (whitePawnCount == 0)
            EndGame(0); // black
        else if (blackPawnCount == 0)
            EndGame(1); // white
    }

    private void EndGame(int winner)
    {
        GameOverPanel.gameObject.SetActive(true);
        GameOverPanel.SetWinnerText(winner);
    }

    public void Forfeit()
    {
        SceneManager.LoadScene("MainMenu");
        //if (turn == PawnColor.White)
        //    EndGame(PawnColor.Black);
        //else if (turn == PawnColor.Black)
        //    EndGame(PawnColor.White);
    }
}