using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    GameData gameData;

    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject newGameMenu;
    [SerializeField]
    GameObject loadGameMenu;

    void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public GameData CurrentGameData {get => gameData; set => gameData = value;}
    public GameObject MainMenu{get => mainMenu; set => mainMenu = value;}
    public GameObject NewGameMenu{get => newGameMenu; set => newGameMenu = value;}
    public GameObject LoadGameMenu{get => loadGameMenu; set => loadGameMenu = value;}
}
