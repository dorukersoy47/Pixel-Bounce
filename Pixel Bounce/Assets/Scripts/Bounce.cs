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
            Vector2 offset = new Vector2(Random.Range(-1f, 1f), 0f); // create a random horizontal offset
            Vector2 forceVector = Vector2.up * force + offset; // combine the vertical and horizontal forces
            rb.AddForce(forceVector, ForceMode2D.Impulse); // apply the force to the ball
            gameManager.IncrementScore();
        }
    }
}