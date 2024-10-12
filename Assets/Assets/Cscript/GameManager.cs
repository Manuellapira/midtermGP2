using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;  // Reference to the Game Over UI Panel
    public TextMeshProUGUI scoreText;  // Reference to the TextMeshPro score UI Text
    public TextMeshProUGUI gameOverText;  // Reference to the TextMeshPro Game Over text
    public Button restartButton;   // Reference to the restart button

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton pattern to ensure there is only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the UI elements
        gameOverUI.SetActive(false);  // Hide the Game Over screen initially
        UpdateScoreText();
        restartButton.onClick.AddListener(RestartGame);
    }

    // Call this method to increase the score
    public void AddScore(int amount)
    {
        if (!isGameOver)
        {
            score += amount;
            UpdateScoreText();
        }
    }

    // Update the score text UI using TextMeshPro
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Call this method when the player dies or the game is over
    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);  // Show the Game Over screen
        gameOverText.text = "Game Over!";  // Update the Game Over text
        Time.timeScale = 0f;  // Pause the game
    }

    // Restart the game by reloading the scene
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}
