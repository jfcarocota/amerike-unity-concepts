using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    [SerializeField]
    string gameName;
    [SerializeField]
    int playerLevel;

    public GameData(string gameName, int playerLevel)
    {
        this.gameName = gameName;
        this.playerLevel = playerLevel;
    }

    public string GameName => gameName;
    public int PlayerLevel {get => playerLevel; set => playerLevel = value > 0 ? value : 1;}
}
