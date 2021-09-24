using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameLibs.MemorySystem;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    Button btnLoadGame;
    [SerializeField]
    TextMeshProUGUI tmpText;

    void Awake()
    {
        btnLoadGame = GetComponent<Button>();
    }

    void Start()
    {
        btnLoadGame.onClick.AddListener(()=>{
            Gamemanager.instance.CurrentGameData = MemorySystem.LoadGame(tmpText.text);
            SceneManager.LoadScene(1);
        });
    }

    public string SetGameName(string gameName) => tmpText.text = gameName;
}
