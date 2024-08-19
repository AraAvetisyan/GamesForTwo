using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPawEndGameManager : MonoBehaviour
{
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    [SerializeField] private GameObject playerOneWinnerMobile, playerTwoWinnerMobile;
    [SerializeField] private CatPawGameUIController _catPawGameUIController;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private Button playerOneButton, playerTwoButton;
    public bool PlOneCantPlay, PlTwoCantPlay;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject end;
    private bool blueWin, redWin;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(_playerOneScript.Points == 5)
        {
            blueWin = true;
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;
            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            
            StartCoroutine(WaitForEnd());
        }
        if(_playerTwoScript.Points == 5)
        {
            redWin = true;
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;

            PlOneCantPlay = true;
            PlTwoCantPlay = true;
           
            StartCoroutine(WaitForEnd());
        }

    }
    public IEnumerator WaitForEnd()
    {
        music.Stop();
        yield return new WaitForSeconds(1f);
        end.SetActive(true);
        finalPanel.SetActive(true);
        if (blueWin)
        {
            playerOneWinnerMobile.SetActive(true);
        }
        if (redWin)
        {
            playerTwoWinnerMobile.SetActive(true);
        }
        
    }
}
