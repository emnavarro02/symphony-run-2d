using System.Collections.Generic;
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

    // Controls the Music between levels
    private GameManager gameManager;
    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        // DeleteAll();
        FillList();

        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();



        if (gameManager.died)
        {
            MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.DieMusicAudio());
            StartCoroutine(Example());
            print("diedddd");

        }
        else
        {
            PlayCorrespondingMusic(0);
        }
    }
        void FillList()
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

                button.GetComponent<Button>().onClick.AddListener(() => LoadLevels("Level" + button.LevelText.text, System.Convert.ToInt32(button.LevelText.text)));

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

        void SaveAll()
        {
            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");

            foreach (GameObject btn in allButtons)
            {
                LevelButton button = btn.GetComponent<LevelButton>();

                //Store Unlocked state
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
            }
        }

        void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        void LoadLevels(string value, int levelNumber)
        {
            //Use scence manager
            SceneManager.LoadScene(value);

            MusicController.Instance.gameObject.GetComponent<AudioSource>().Stop();

            PlayCorrespondingMusic(levelNumber);
        }


        void PlayCorrespondingMusic(int level)
        {
            if (level == 0)
            {
                //MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioLevelManager();

                MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.GetAudioLevelManager());
            }
            if (level == 1)
            {
                MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = musicManager.GetAudioLevel1();
                MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Stop();
        //MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
        PlayCorrespondingMusic(0);
        print(Time.time);
    }
}
