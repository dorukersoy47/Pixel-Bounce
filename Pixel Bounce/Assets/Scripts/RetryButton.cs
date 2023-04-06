using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
