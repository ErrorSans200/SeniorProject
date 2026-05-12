//This script controls the behavior of a normal bullet. It has a lifetime and does damage to things with health. When it hits something, it is destroyed.

using UnityEngine;

public class NormalBulletScript : MonoBehaviour
{

   
    public float lifetime = 2f; // How long thing exists before it disappears
    public float damage = 10f; // How much damage thing does to things with health
   






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy thing after it's expiration date
    }
        
         
    void OnTriggerEnter2D(Collider2D other)
    {

    
       Health health = other.GetComponent<Health>();
    
       if (health != null)
       {
        health.TakeDamage(damage);
        Destroy(gameObject); // Destroy the bullet after it hits something

        }//End If
       
    
    }//End OnTriggerEnter2D






}//End NormalBulletScript
