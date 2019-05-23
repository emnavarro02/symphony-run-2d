using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int notesScore = 0;

    private int claveScore = 0;

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
        notesScore++;
        scoreText.text = "Notes: " + notesScore.ToString()+" Claves: " + claveScore.ToString();
        Debug.Log("score:" + notesScore);
    }

    public void IncreaseClaves()
    {
        claveScore++;
        scoreText.text = "Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString();
        Debug.Log("score:" + notesScore);
    }
}
