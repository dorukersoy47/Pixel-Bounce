using UnityEngine;
using UnityEngine.EventSystems;

public class Bounce : MonoBehaviour, IPointerDownHandler
{
    public float force = 10f;
    Rigidbody2D rb;
    public GameObject gameOverCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        { 
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
    }
}
