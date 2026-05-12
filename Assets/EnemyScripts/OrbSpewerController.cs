using Unity.VisualScripting;
using UnityEngine;

public class OrbSpewerController : Weapon
{

    public Transform FirePoint; // The point from which the orb will be fired
    public GameObject OrbPrefab; // The prefab of the orb to be fired
   
    public float fireInterval = 0.2f; // Time between each shot
    private float nextFireTime = 0f; // Time when the next shot can be fired
    public float orbSpeed = 10f; // Speed at which the orb will travel
    float baseAngle = 0f; // your weapon's forward angle
    float spread = 15f;    // degrees of randomness

  

    public override void Shoot()
    {

        if (nextFireTime <= Time.time)
        {
            Debug.Log("Cooldown should have applied. Did it work?");

          
            float randomAngle = Random.Range(-spread, spread);
            float finalAngle = baseAngle + randomAngle;

            float radians = finalAngle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(
                Mathf.Cos(radians),
                Mathf.Sin(radians)
            );
            baseAngle = FirePoint.rotation.eulerAngles.z; // Update baseAngle to the current rotation of the FirePoint
            GameObject orb = Instantiate(OrbPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = orb.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * orbSpeed;

            nextFireTime = Time.time + fireInterval; // Update the next fire time based on the cooldown


        }

    }
}
