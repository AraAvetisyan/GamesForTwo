using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private SecondPlayerZoneTrigger _secondPlayerZoneTrigger;
    [SerializeField] private FirstPlayerZoneTrigger _firstPlayerZoneTrigger;
    [SerializeField] private GameObject firstPlayerWin, secondPlayerWin, draw;
    [SerializeField] private GameObject finalPanel;
    private void OnEnable()
    {
        TimerScript.GameEnds += EndGame;
    }
    private void OnDisable()
    {
        TimerScript.GameEnds -= EndGame;
    }
    public void EndGame(bool bb)
    {
        if (_secondPlayerZoneTrigger.FirstPlayersPoints > _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            firstPlayerWin.SetActive(true);
        }
        if (_secondPlayerZoneTrigger.FirstPlayersPoints < _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            secondPlayerWin.SetActive(true);
        }
        if(_secondPlayerZoneTrigger.FirstPlayersPoints == _firstPlayerZoneTrigger.SecondPlayersPoints)
        {
            draw.SetActive(true);
        }

    }
    public IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(3);
        finalPanel.SetActive(true);
    }
}
