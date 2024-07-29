using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPawEndGameManager : MonoBehaviour
{
    [SerializeField] private PlayerOneScript _playerOneScript;
    [SerializeField] private PlayerTwoScript _playerTwoScript;
    [SerializeField] private GameObject playerOneWinnerMobile, playerTwoWinnerMobile;
    [SerializeField] private GameObject playerOneWinnerPC, playerTwoWinnerPC;
    [SerializeField] private CatPawGameUIController _catPawGameUIController;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private Button playerOneButton, playerTwoButton;
    public bool PlOneCantPlay, PlTwoCantPlay;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(_playerOneScript.Points == 5)
        {
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;
            PlOneCantPlay = true;
            PlTwoCantPlay = true;
            
            StartCoroutine(WaitForEnd());
        }
        if(_playerTwoScript.Points == 5)
        {
            playerOneButton.interactable = false;
            playerTwoButton.interactable = false;

            PlOneCantPlay = true;
            PlTwoCantPlay = true;
           
            StartCoroutine(WaitForEnd());
        }

    }
    public IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1.5f);
        finalPanel.SetActive(true);
        if (_catPawGameUIController.IsMobile && !_catPawGameUIController.IsSingle)
        {
            playerOneWinnerMobile.SetActive(true);
        }
        if (!_catPawGameUIController.IsMobile || _catPawGameUIController.IsSingle)
        {
            playerOneWinnerPC.SetActive(true);
        }
        if (_catPawGameUIController.IsMobile && !_catPawGameUIController.IsSingle)
        {
            playerTwoWinnerMobile.SetActive(true);
        }
        if (!_catPawGameUIController.IsMobile || _catPawGameUIController.IsSingle)
        {
            playerTwoWinnerPC.SetActive(true);
        }
    }
}
