using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float turnSpeed = 90f;
    public Color[] colors = { Color.red, Color.green, Color.yellow };

    private int currentColorIndex = 0;
    private Color currentColor;
    private bool isGameOver = false;

    void Start()
    {
        currentColor = colors[currentColorIndex];
    }

    void Update()
    {
        if (isGameOver) return;

        // Turn the player
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed);
        }

        // Shoot bullet
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Change color
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetColor(currentColor);
    }

    void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        currentColor = colors[currentColorIndex];
    }

    public void GameOver()
    {
        isGameOver = true;
        // Trigger game over UI here
    }
}