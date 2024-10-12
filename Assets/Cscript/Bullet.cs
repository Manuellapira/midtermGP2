using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Color bulletColor;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetColor(Color color)
    {
        bulletColor = color;
        // Set bullet material color (optional)
        GetComponent<Renderer>().material.color = bulletColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null && enemy.GetColor() == bulletColor)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
