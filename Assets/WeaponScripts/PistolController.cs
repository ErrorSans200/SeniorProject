//This script controls the pistol weapon. It can be attached to a weapon holder. It will shoot one bullet at a time from a fire point. The bullet will have a cooldown before it can be fired again.

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PistolController : Weapon
{

   
    public GameObject Bullet; //This is thing that thing will shoot
    public Transform FirePoint;//This is where thing come out of thing.  
    public float bulletSpeed; //This is how fast thing will go.
    public float coolDown; // Time between when thing can fire more things
    private float nextFireTime = 0f;

    public override void Shoot()
    {

        if (nextFireTime <= Time.time)
        {

            Debug.Log("Cooldown should have applied. Did it work?");

            GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = FirePoint.right * bulletSpeed;

            nextFireTime = Time.time + coolDown; // Update the next fire time based on the cooldown


        }
        
    }



}
