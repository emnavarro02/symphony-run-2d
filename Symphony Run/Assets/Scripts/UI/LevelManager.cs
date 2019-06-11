﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    [System.Serializable]
    public class Level
    {
        public string levelText;
        public int isUnlocked; //if 0 = locked; if 1 = unlocked
        public bool isInteractable;
    }

    public GameObject levelButton;
    public Transform spacer;
    public List<Level> levelList;
        
    private GameManager gameManager;   // Hold common values and parameters between the Scenes.
    private MusicManager musicManager; // Singleton which contains all audio clips to be played.
    private LevelChanger levelChanger; // Object that control the Fade Animation.

    private Text generalScore;

    // Start is called before the first frame update
    private void Start()
    {

        // DeleteAll();

        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
        levelChanger = FindObjectOfType<LevelChanger>();


        //if (!PlayerPrefs.HasKey("notes"))
        //{
            int score = PlayerPrefs.GetInt("notes");
        Debug.Log("score desde level manager"+score);
            //generalScore.text = score.ToString();
        //}
        generalScore = GameObject.Find("Score").GetComponent<Text>();
        generalScore.text = "Score: "+score.ToString();
        MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioClip(SceneManager.GetActiveScene().buildIndex);
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();

        FillList(); // Load all buttons and fill the grid view of the main screen.
    }

    /**
     *  Load all buttons and fill the grid view of the main screen.
    */
    private void FillList()
    {
        foreach (var level in levelList)
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButton button = newButton.GetComponent<LevelButton>();
            button.LevelText.text = level.levelText;

            // The Level name must be: Levell, Level2
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                //set Level to be unlocked
                //gameManager.PlayFirstLevelMusic();
                level.isUnlocked = 1;
                level.isInteractable = true;
            }

            //update the button value
            button.unlocked = level.isUnlocked;
            button.GetComponent<Button>().interactable = level.isInteractable;

            //Detect the button clicked 
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel("Level" + button.LevelText.text, System.Convert.ToInt32(button.LevelText.text)));

            //Debug.Log("LevelText: " + button.LevelText.text);
            //Debug.Log("Value: " + PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score"));
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 1)
            {
                button.Star1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 2)
            {
                button.Star2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") == 3)
            {
                button.Star3.SetActive(true);
            }

            newButton.transform.SetParent(spacer);
        }

        SaveAll();
    }

    private void SaveAll()
    {
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");

        foreach (GameObject btn in allButtons)
        {
            LevelButton button = btn.GetComponent<LevelButton>();

            //Store Unlocked state
            PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
        }
    }

    private void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    /**
     * Prepare the next level to load by stopping the current music, loading the next music and starting the new Scene. 
     */
    private void LoadLevel(string value, int levelNumber)
    {
        gameManager.currentLevel = levelNumber;
        GetPersistedData();

        // Calling the FadeOut script. The SceneManager.LoadScene is called there.
        levelChanger.FadeToLevel(levelNumber);
    }

    //private void PlayCorrespondingMusic(int level)
    //{
    //    switch (level)
    //    {
    //        case 0:
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.GetAudioLevelManager());
    //            break;
    //        case 1:
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioLevel1();
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
    //            break;
    //        case 2:
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioLevel2();
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
    //            break;
    //        case 3:
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioLevel3();
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
    //            break;
    //        case 5:
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.DieMusicAudio();
    //            MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
    //            break;
    //    }
    //}

    ///**
    // * Play the Died Music for some seconds and then change it to the music of the Level Selection Screen
    // */
    //private IEnumerator Timer()
    //{
    //    print(Time.time);
    //    yield return new WaitForSeconds(5); // wait for 5 seconds
    //    MusicController.Instance.gameObject.GetComponent<AudioSource>().Stop();
    //    PlayCorrespondingMusic(0); // 0 = Level Selection Screen
    //}

    public void GetPersistedData()
    {
        //player.SetPlayerLife(PlayerPrefs.GetInt("life"));
    }
}
