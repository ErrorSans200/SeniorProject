using UnityEngine;

public class HealthBoxScript : MonoBehaviour
{

    public float healAmount = 25f; // Amount of health to restore when the player collides with the health box

    void OnTriggerEnter2D(Collider2D collision)
    {

        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            Debug.Log("Health box gave health to " + collision.gameObject.name);
            health.Heal(healAmount);
            Destroy(gameObject); //Destroy the health box after it has been used

        }//End If

       


    }//End OnTriggerEnter2D
}//End HealthBoxScript
