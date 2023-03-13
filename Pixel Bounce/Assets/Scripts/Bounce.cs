using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bounce : GameManager, IPointerDownHandler
{
    public float force = 10f;
    Rigidbody2D rb;
    public GameObject gameOverCanvas;
    private GameManager gameManager;

    public Button retryButton;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bottomFloor"))
        {
            gameOverCanvas.SetActive(true);
            retryButton.onClick.AddListener(OnClickRetry);
            Time.timeScale = 0f;
        }
        else if (collision.gameObject.CompareTag("Foot"))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            gameManager.Score += 1;
        }
    }

    void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}