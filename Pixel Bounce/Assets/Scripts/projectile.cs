using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Sprite[] projectileSprites; // Array of projectile sprites
    public float speed = 5.0f;
    public float spawnRange = 5.0f;
    public bool isMovingRight = true;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set a random sprite for the projectile
        int randomIndex = Random.Range(0, projectileSprites.Length);
        spriteRenderer.sprite = projectileSprites[randomIndex];

        // Set the initial position of the projectile
        float randomHeight = Random.Range(-spawnRange, spawnRange);
        transform.position = new Vector3(isMovingRight ? -10.0f : 10.0f, randomHeight, 0.0f);

        // Make the projectile visible
        spriteRenderer.enabled = true;
    }

    private void Update()
    {
        // (Same as before)
    }
}
