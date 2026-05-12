using UnityEngine;

public class OrbController : MonoBehaviour
{
    public float orbLifetime = 2f; // Time after which the orb will be destroyed
    public float damage = 10f; // How much damage the orb does to things with health


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, orbLifetime); // Destroy thing after it's expiration date
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.LogWarning("Orb: I just hit '{other.gameObject.name}'");


        // Check if the collided object has a health component
        Health health = other.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);

        }//End If
        Destroy(gameObject); // Destroy the orb after it hits something

    }//End OnTriggerEnter2D
}
