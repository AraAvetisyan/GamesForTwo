using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPawEndGameManager : MonoBehaviour
{
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    [SerializeField] private GameObject playerOneWinner, playerTwoWinner;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private Button playerOneButton, playerTwoButton;
    public bool PlOneCantPlay, PlTwoCantPlay;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(_playerOneScript.Points == 3)
        {
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;
            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            playerOneWinner.SetActive(true);
            StartCoroutine(WaitForEnd());
        }
        if(_playerTwoScript.Points == 3)
        {
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;

            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            playerTwoWinner.SetActive(true);
            StartCoroutine(WaitForEnd());
        }

    }
    public IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
    }
}
