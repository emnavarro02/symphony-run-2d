using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //TODO: Persist values when game close
    private int overallNotesScore;

    private int claveScore;

    private int playerLife;

    public bool died = false;
    public int currentLevel; //used by GameOver to load the current level  => Retry? = Yes

    private Text generalScore;

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

    private void Start()
    {
        print("LOAD");

    }

    // Keep the overal notes collected on the game
    public void SetOverallNotesScore(int notes)
    {
        overallNotesScore = notes;
    }

    // the clafs on the last level
    public void SetClafScore(int clave)
    {
        claveScore = clave;
    }

    public void SetOverallPlayerLife(int life)
    {
        playerLife = life;
    }

    public int GetNotesScore(){
        return overallNotesScore;
    }

    public void EndLevel()
    {
        PersistData();
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
            //PersistData();
            LevelChanger.FindObjectOfType<LevelChanger>().FadeToLevel(0); // Load the MainScene with Fade.
        }
        else
        {
            //PersistData();
            // Loads the GameOver Scene: 
            LevelChanger.FindObjectOfType<LevelChanger>().FadeToLevel(5); // Load the GameOver Scene with Fade.
        }
    }

    public void PersistData()
    {
        if (PlayerPrefs.HasKey("notes"))
        {
            int notes = PlayerPrefs.GetInt("notes");
            PlayerPrefs.SetInt("notes", GetNotesScore()+notes);
        }
        else
        {
            PlayerPrefs.SetInt("notes", GetNotesScore());
        }

        print("notes scoreee: " + PlayerPrefs.GetInt("notes"));
    }
}