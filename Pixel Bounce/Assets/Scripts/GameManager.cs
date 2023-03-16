using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;

    private const string highScoreKey = "HighScore";

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateUI();
        }
    }

    public int HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            PlayerPrefs.SetInt(highScoreKey, highScore);
            UpdateUI();
        }
    }

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        HighScore = highScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        GameObject currentScoreTextObj = GameObject.Find("CurrentScoreText");
        GameObject highScoreTextObj = GameObject.Find("HighScoreText");

        if (currentScoreTextObj != null && highScoreTextObj != null)
        {
            Text currentScoreText = currentScoreTextObj.GetComponent<Text>();
            Text highScoreText = highScoreTextObj.GetComponent<Text>();
            currentScoreText.text = Score.ToString();
            highScoreText.text = "High Score: " + HighScore.ToString();
        }
    }
}