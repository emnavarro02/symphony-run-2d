using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //TODO: Persist values when game close
    private int overallNotesScore;

    private int claveScore;

    private int playerLife;

    public bool died = false;




    private static GameManager instance = null;


    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        print("LOAD");

    }

    // Keep the overal notes collected on the game
    public void setOverallNotesScore(int notes)
    {
        overallNotesScore += notes;
    }

    // the clafs on the last level
    public void setClafScore(int clave)
    {
        claveScore = clave;
    }

    public void setOverallPlayerLife(int life)
    {
        playerLife = life;
    }

    public int GetNotesScore(){
        return overallNotesScore;
    }

    public void EndLevel()
    {
        if (!died)
        {
            print("NOT DIED: " + claveScore); 
            //if collected all the claves, unlock next level
            if (claveScore >= 3)
            {
                //unlock next levels
                PlayerPrefs.SetInt("Level2", 1); // Key: LevelName, Value: 1=unlocked / 0=locked
            }

            if (PlayerPrefs.GetInt("Level1_score") < claveScore)
            {
                // Get score to show stars.
                PlayerPrefs.SetInt("Level1_score", claveScore);
            }

        }

        SceneManager.LoadScene(0);
    }
}