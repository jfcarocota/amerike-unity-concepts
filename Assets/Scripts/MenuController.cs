using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameLibs.MemorySystem;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button btnNewGame;
    [SerializeField]
    Button btnLoadGame;
    [SerializeField]
    Button btnQuitGame;
    [SerializeField]
    GameObject pnlNewGame;

    void OnEnable()
    {
        //Load Game enabled ?
        btnLoadGame.gameObject.SetActive(MemorySystem.FilePaths.Length > 0);
    }

    void Awake()
    {
        btnQuitGame.onClick.AddListener(()=>{
            Application.Quit();
        });

        btnNewGame.onClick.AddListener(()=>{
            Gamemanager.instance.NewGameMenu.SetActive(true);
            gameObject.SetActive(false);
        });

        btnLoadGame.onClick.AddListener(()=>{
            
        });
    }

    void Start()
    {
        Gamemanager.instance.MainMenu = gameObject;
    }
}
