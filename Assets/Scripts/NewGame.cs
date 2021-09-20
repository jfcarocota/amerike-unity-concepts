using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameLibs.MemorySystem;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField]
    Button btnNewGame;
    [SerializeField]
    InputField inflGameName;

    void Awake()
    {
        btnNewGame.onClick.AddListener(()=>{
            if(!string.IsNullOrEmpty(inflGameName.text))
            {
                MemorySystem.NewGame(inflGameName.text);
                Gamemanager.instance.CurrentGameData = MemorySystem.LoadGame(inflGameName.text);
                SceneManager.LoadScene(1);
            }
        });
    }

    void Start()
    {
        Gamemanager.instance.NewGameMenu = gameObject;
        gameObject.SetActive(false);
    }
}
