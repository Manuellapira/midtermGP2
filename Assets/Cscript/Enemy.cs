using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Color enemyColor;
    private GameObject player;  // Define the player variable

    void Start()
    {
        // Find the player GameObject in the scene
        player = GameObject.FindWithTag("Player");

        // Set random color
        Color[] colors = { Color.red, Color.green, Color.yellow };
        enemyColor = colors[Random.Range(0, colors.Length)];
        GetComponent<Renderer>().material.color = enemyColor;
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public Color GetColor()
    {
        return enemyColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Call GameOver from PlayerController
            player.GetComponent<PlayerController>().GameOver();
        }
    }
}
