using JetBrains.Annotations;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public Text highScoreText;
    public int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    
}