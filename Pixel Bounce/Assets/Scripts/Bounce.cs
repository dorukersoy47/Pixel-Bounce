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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (gameObject.CompareTag("Ball")) {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
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
            Time.timeScale = 0f;
        }
        else if (collision.gameObject.CompareTag("Foot"))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            gameManager.IncrementScore();
        }
    }
}