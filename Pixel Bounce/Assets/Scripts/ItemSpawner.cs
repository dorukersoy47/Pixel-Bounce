using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public GameObject[] itemPrefabs; // An array of GameObjects to choose from
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float minHeight = 1f;
    public float maxHeight = 4f;
    public float minSideForce = 2f;
    public float maxSideForce = 5f;
    public GameObject targetObject; // The object that will destroy the item

    void Start()
    {
        InvokeRepeating("SpawnItem", 1f, 2f);
    }

    void SpawnItem()
    {
        // Choose a random item from the array
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject itemPrefab = itemPrefabs[randomIndex];

        // Instantiate the item and set its position
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        // Set random height and side force
        float height = Random.Range(minHeight, maxHeight);
        float sideForce = Random.Range(minSideForce, maxSideForce);

        // Calculate the direction vector based on the side force
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), height).normalized;
        direction.x *= sideForce;

        // Set the velocity of the item's Rigidbody component
        float speed = Random.Range(minSpeed, maxSpeed);
        item.GetComponent<Rigidbody2D>().velocity = direction * speed;

        // Add a BoxCollider2D and DestroyOnContact script to the item
        BoxCollider2D collider = item.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        DestroyOnContact destroyScript = item.AddComponent<DestroyOnContact>();
        destroyScript.targetObject = targetObject;
    }

    public class DestroyOnContact : MonoBehaviour
    {

        public GameObject targetObject;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == targetObject)
            {
                Destroy(gameObject);
            }
        }
    }
}