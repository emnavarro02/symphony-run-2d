using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Button yesButton;

    [SerializeField]
    private Button noButton;

    [SerializeField]
    private readonly int delay = 0;

    private void Main()
    {
        MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<MusicManager>().GetAudioClip(SceneManager.GetActiveScene().buildIndex);
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();

        yesButton.onClick.AddListener(() => Invoke("LoadPreviousLevel", delay));
        noButton.onClick.AddListener(() => Invoke("LoadMainScreen", delay));
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
