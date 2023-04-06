using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateUI();
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        GameObject currentScoreTextObj = GameObject.Find("CurrentScoreText");

        if (currentScoreTextObj != null)
        {
            Text currentScoreText = currentScoreTextObj.GetComponent<Text>();
            currentScoreText.text = Score.ToString();
        }
    }
}