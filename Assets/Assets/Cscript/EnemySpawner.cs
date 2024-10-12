using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;  // Array of spawn points
    public float spawnDelay = 3f;    // Delay between spawns

    void Start()
    {
        // Start the coroutine to spawn enemies
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine for spawning enemies
    IEnumerator SpawnEnemies()
    {
        while (true) // Infinite loop to keep spawning
        {
            // Wait for 3 seconds between spawns
            yield return new WaitForSeconds(spawnDelay);

            // Randomly decide how many enemies to spawn (between 1 and 5)
            int enemyCount = Random.Range(1, 6);

            // Spawn the enemies
            for (int i = 0; i < enemyCount; i++)
            {
                // Choose a random spawn point from the array
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instantiate the enemy at the selected spawn point
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
