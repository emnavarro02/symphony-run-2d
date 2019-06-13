﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    [SerializeField]
    private readonly int delay = 0;

    private void Update()
    {
        if (Input.GetKeyDown(0))
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) 
        {
            print("Clicked");
            LoadMainScreen();
        }
    }

    private void LoadPreviousLevel()
    {
        LevelChanger.FindObjectOfType<LevelChanger>().FadeToLevel(FindObjectOfType<GameManager>().currentLevel);
    }

    private void LoadMainScreen()
    {
        LevelChanger.FindObjectOfType<LevelChanger>().FadeToLevel(0);
    }
}
