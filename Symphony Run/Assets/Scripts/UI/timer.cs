using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private readonly int score = 3;

    // Start is called before the first frame update
    private void Start()
    {
        //unlock next levels
        PlayerPrefs.SetInt("Level2", 1); // Key: LevelName, Value: 1=unlocked / 0=locked

        // Get score to show stars.
        PlayerPrefs.SetInt("Level1_score", score);
        StartCoroutine(Time());
    }

    private IEnumerator Time()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
