using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameFinished : MonoBehaviour
{
    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private readonly int delay = 2;

    private void Main()
    {
        homeButton.onClick.AddListener(() => Invoke("LoadMainScreen", delay));
    }

    private void LoadMainScreen()
    {
        LevelChanger.FindObjectOfType<LevelChanger>().FadeToLevel(0);
    }
}
