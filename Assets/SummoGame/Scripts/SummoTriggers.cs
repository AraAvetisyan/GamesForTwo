using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummoTriggers : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private Transform playerOneStartPos, playerTwoStartPos;
    [SerializeField] private GameObject playerOneObject, playerTwoObject;
    [SerializeField] private int playerOnePoints, playerTwoPoints;
    [SerializeField] private TextMeshProUGUI playerOnePointsText, playerTwoPointsText;
    [SerializeField] private SummoGameScript _summoGameScriptPlOne, _summoGameScriptPlTwo;

    [SerializeField] private Button playerOneButton, playerTwoButton;

    [SerializeField] private GameObject playerOneWin, playerTwoWin;
    [SerializeField] private GameObject finalPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NotTrigger")
        {
            if (playerIndex == 1)
            {
                _summoGameScriptPlOne.PlayerOneIsHolding = false;
                _summoGameScriptPlTwo.PlayerTwoIsHolding = false;
                playerOneObject.transform.position = playerOneStartPos.position;
                playerTwoObject.transform.position = playerTwoStartPos.position;
                playerTwoPoints++;
                playerTwoPointsText.text = playerTwoPoints.ToString();
                if(playerTwoPoints == 3)
                {
                    playerTwoWin.SetActive(true);
                    playerOneButton.interactable = false;
                    playerTwoButton.interactable = false;
                    StartCoroutine(WaitToWin());
                }
                Debug.Log("Pl 2 Win");
            }
            if (playerIndex == 2)
            {
                _summoGameScriptPlOne.PlayerOneIsHolding = false;
                _summoGameScriptPlTwo.PlayerTwoIsHolding = false;
                playerOneObject.transform.position = playerOneStartPos.position;
                playerTwoObject.transform.position = playerTwoStartPos.position;
                playerOnePoints++;
                playerOnePointsText.text = playerOnePoints.ToString();
                if(playerOnePoints == 3)
                {
                    playerOneWin.SetActive(true);
                    playerOneButton.interactable = false;
                    playerTwoButton.interactable = false;
                    StartCoroutine(WaitToWin());
                }
                Debug.Log("Pl 1 Win");
            }
        }
    }
    public IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
