using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Color enemyColor;
    private GameObject player;

    void Start()
    {
        // Find the player object
        player = GameObject.FindWithTag("Player");

        // Set the enemy's color randomly (Red, Green, Yellow)
        Color[] colors = { Color.red, Color.green, Color.yellow };
        enemyColor = colors[Random.Range(0, colors.Length)];
        GetComponent<Renderer>().material.color = enemyColor;
    }

    void Update()
    {
        // Move towards the player if they exist
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public Color GetColor()
    {
        return enemyColor;
    }

    // Handle collision with player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Trigger the game over logic in the GameManager
            GameManager.instance.GameOver();
        }
    }

    // Call this method when the enemy is destroyed
    public void DestroyEnemy()
    {
        // Add score when the enemy is destroyed
        GameManager.instance.AddScore(10);  // Increase score by 10 points
        Destroy(gameObject);  // Destroy the enemy
    }
}
