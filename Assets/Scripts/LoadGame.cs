using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLibs.MemorySystem;
using System.IO;

public class LoadGame : MonoBehaviour
{

    [SerializeField]
    Object btnLoadSrc;

    void OnEnable()
    {
        ChildrenClear();
        foreach (FileInfo item in MemorySystem.FilePaths)
        {
            Debug.Log(item.Name);
            PanelPupulate(Path.GetFileNameWithoutExtension(item.Name));
        }
    }

    void Start()
    {
        Gamemanager.instance.LoadGameMenu = gameObject;
        gameObject.SetActive(false);
    }

    void ChildrenClear()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void PanelPupulate(string gameName)
    {
        GameObject goBntLoad = (GameObject) Instantiate(btnLoadSrc, Vector2.zero, Quaternion.identity);
        goBntLoad.transform.parent = transform;
        LoadGameButton loadGameButton = goBntLoad.GetComponent<LoadGameButton>();
        loadGameButton.SetGameName(gameName);
    }
}
