using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;

    public int Score 
    {
        get { return score; }
        set { 
            score = value; 
            UpdateUI(); // call UpdateUI method to update the score text
        }
    }

    public int HighScore 
    {
        get { return highScore; }
        set { 
            highScore = value; 
            UpdateUI(); // call UpdateUI method to update the high score text
        }
    }

    void UpdateUI()
    {
        // Find the text objects and update their text values
        GameObject currentScoreTextObj = GameObject.Find("CurrentScoreText");
        GameObject highScoreTextObj = GameObject.Find("HighScoreText");
        
        if (currentScoreTextObj != null && highScoreTextObj != null)
        {
            Text currentScoreText = currentScoreTextObj.GetComponent<Text>();
            Text highScoreText = highScoreTextObj.GetComponent<Text>();
            currentScoreText.text = "Score: " + Score.ToString();
            highScoreText.text = "High Score: " + HighScore.ToString();
        }
    }
}