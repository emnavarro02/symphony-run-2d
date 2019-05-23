using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseNotes()
    {
        score += 1; //score++;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("score:" + score);
    }
}
