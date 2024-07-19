using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGameManager : MonoBehaviour
{
    [SerializeField] GuardTimer _guardTimer;
    [SerializeField] PlayersTrigger _playersTriggerOne, _playersTriggerTwo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playersTriggerOne.GuardWin || _playersTriggerTwo.GuardWin)
        {
            _playersTriggerOne.GuardWin = false;
            _playersTriggerTwo.GuardWin = false;
            
            if (_guardTimer.Test == 1)
            {
                _guardTimer.GameEnds = true;
                _guardTimer.IsSecondGame = true;
                //_guardTimer.SecondGameEnds = true;
            }
            if (_guardTimer.Test == 2)
            {
                // _guardTimer.GameEnds = true;

                _guardTimer.IsSecondGame = false;
                _guardTimer.GameEnds = true;
            }
        }
    }
}
