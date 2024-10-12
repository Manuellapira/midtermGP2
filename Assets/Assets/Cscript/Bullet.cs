using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Color bulletColor;

    void Update()
    {
        // Move the bullet forward continuously
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetColor(Color color)
    {
        bulletColor = color;
        // Set the bullet's color
        GetComponent<Renderer>().material.color = bulletColor;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            // If the bullet color matches the enemy color, destroy the enemy
            if (enemy != null && enemy.GetColor() == bulletColor)
            {
                enemy.DestroyEnemy();  // Call the method to add score and destroy the enemy
                Destroy(gameObject);  // Destroy the bullet as well
            }
        }
    }
}
