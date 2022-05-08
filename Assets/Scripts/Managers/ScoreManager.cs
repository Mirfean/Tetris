using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    int lines;
    [SerializeField]
    int linesToNextLevel;
    [SerializeField]
    int level;
    [SerializeField]
    int score;

    [SerializeField]
    TextMeshProUGUI scoreUI;
    [SerializeField]
    TextMeshProUGUI linesUI;
    [SerializeField]
    TextMeshProUGUI levelUI;

    public int LinesToNextLevel { 
        get => linesToNextLevel;
        set
        {
            linesToNextLevel = value;
            if (linesToNextLevel <= 0)
            {
                Level += 1;
                linesToNextLevel = SetNextLineLevel();
            } 
        }
    }

    public int Lines { 
        get => lines;
        set {
            lines = value;
            linesUI.text = lines.ToString();
        } 
    }

    public int Score { 
        get => score;
        set 
        { 
            score = value;
            scoreUI.text = ScoreText();
        }  
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;
            levelUI.text = level.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Lines = 0;
        Level = 1;
        LinesToNextLevel = SetNextLineLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int SetNextLineLevel()
    {
        return 4 + ((level - 1) * 3);
    }

    public void SetScoreAndLines(int linesCleared)
    {
        switch (linesCleared)
        {
            case 1:
                Score += 100 * level;
                break;
            case 2:
                Score += 250 * level;
                break;
            case 3:
                Score += 500 * level;
                break;
            case 4:
                Score += 1000 * level;
                break;
        }
        Lines += linesCleared;
        LinesToNextLevel = LinesToNextLevel - linesCleared;
    }

    string ScoreText()
    {
        string scoreText = score.ToString();
        while (scoreText.Length < 7)
        {
            scoreText = "0" + scoreText;
        }
        return scoreText;
    }

}
