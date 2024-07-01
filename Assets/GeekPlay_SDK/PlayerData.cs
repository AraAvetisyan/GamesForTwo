using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Coins { 
        get
        {
            return _coinsDontUse;
        }
        set
        {
            _coinsDontUse = value;
            CoinsChanged?.Invoke(_coinsDontUse);
        }
    }

    public bool GunBought;
    public bool PistolBought;
    public bool KnifeBought;
    public bool BetBought;
    public bool ShotgunBought;
    public bool RPGBought;

    public int GunBulletCount;
    public int PistolBulletCount;
    public int ShotgunBulletCount;
    public int RPGBulletCount;
    public int GrenadeCount;

    public Vector3 PlayerPosition;
    public int Money;
    public float XP;
    public int CurrentXP;
    public event Action<int> CoinsChanged;
    public int _coinsDontUse;

    public bool IsFirstPlay;

    public int BuildCount;
    public int DestroyCount;



   

    public int CurrentSaveSlotLoading;
    public bool IsPlayerMapLoad;
    /////InApps//////
    public string lastBuy;
}