//This script controls the shotgun weapon. It can be attached to a weapon holder. It will shoot three bullets at once, each from a different fire point. The bullets will have a cooldown before they can be fired again.

using UnityEngine;

public class ShotGunController : Weapon
{
    public GameObject Bullet; //This is thing that thing will shoot
    public Transform FirePoint1;//This is where thing come out of thing.  
    public Transform FirePoint2;//This is where thing come out of thing.  
    public Transform FirePoint3;//This is where thing come out of thing.  
    public float bulletSpeed; //This is how fast thing will go.
    public float coolDown; // Time between when thing can fire more things
    private float nextFireTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Shoot()
    {

        if (nextFireTime <= Time.time)
        {
            Debug.Log("Cooldown should have applied. Did it work?");
            GameObject bullet1 = Instantiate(Bullet, FirePoint1.position, FirePoint1.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.linearVelocity = FirePoint1.right * bulletSpeed;
            GameObject bullet2 = Instantiate(Bullet, FirePoint2.position, FirePoint2.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.linearVelocity = FirePoint2.right * bulletSpeed;
            GameObject bullet3 = Instantiate(Bullet, FirePoint3.position, FirePoint3.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.linearVelocity = FirePoint3.right * bulletSpeed;
            nextFireTime = Time.time + coolDown; // Update the next fire time based on the cooldown









        }

    }
}
