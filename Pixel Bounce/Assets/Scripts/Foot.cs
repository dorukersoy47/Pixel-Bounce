using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    public Camera mainCamera;
    public float maxVerticalOffset = 0.3f; // maximum vertical distance from the bottom of the screen
    public float rotateSpeed = 5f; // speed of rotation towards the top center of the screen
    public float movementSpeed = 5f; // speed of horizontal movement
    public Collider2D[] collidersToIgnore;

    private Rigidbody2D rb;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        mousePos.z = transform.position.z - mainCamera.transform.position.z;
        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(mousePos);

        // Get the position of the top center of the screen in world space
        Vector3 topCenterScreenPos = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f - maxVerticalOffset / mainCamera.pixelHeight, worldMousePos.z));
        // Get the position of the bottom center of the screen in world space
        Vector3 bottomCenterScreenPos = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, maxVerticalOffset / mainCamera.pixelHeight, worldMousePos.z));

        // Clamp the vertical position to a maximum offset from the bottom of the screen
        float verticalOffset = Mathf.Clamp(worldMousePos.y - bottomCenterScreenPos.y, 0, maxVerticalOffset);
        Vector3 clampedMousePos = new Vector3(worldMousePos.x, bottomCenterScreenPos.y + verticalOffset, worldMousePos.z);

        // Update the position of the foot
        rb.MovePosition(Vector2.MoveTowards(transform.position, clampedMousePos, movementSpeed * Time.fixedDeltaTime));
        
        // Check if foot collides with any colliders in the scene
        if (Physics2D.OverlapArea(transform.position, lastPosition, LayerMask.GetMask("Colliders")))
        {
            // Revert the position of the foot to the last position
            rb.MovePosition(lastPosition);
        }
        else
        {
            // Update last position with current position if there was no collision
            lastPosition = transform.position;
        }

        // Rotate the foot towards the top center of the screen
        Vector3 cameraPos = mainCamera.transform.position;
        Vector3 centerPos = new Vector3(cameraPos.x, topCenterScreenPos.y + maxVerticalOffset / 2f, cameraPos.z);
        Vector3 direction = centerPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
