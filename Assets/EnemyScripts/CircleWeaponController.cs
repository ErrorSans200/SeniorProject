//This script controlls the circle enemy's weapon. It makes the weapon rotate around the enemy and shoot at the player.




using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleWeaponController : MonoBehaviour
{

    //properties
    private Weapon currentWeapon;
    [SerializeField] private Transform player;
    [SerializeField]  private float orbitDist = 1.5f;

    //properties related to shooting
    public float nextFireTime = 0f; // Time when the holder fires again. 
    public float fireCoolDown= 1.0f; // Time inbetween shots.




    void Start()
    {


        GameObject foundPlayer = FindPlayer();

        if (foundPlayer == null)
        {
            Debug.LogError("Player is NULL on " + gameObject.name);
        }
        else
        {
            player = foundPlayer.transform;
            Debug.Log("Player assigned: " + player.name);
        }




        currentWeapon = GetComponentInChildren<Weapon>();

       

    }//End Start

    void Update()
    {
        if (player == null)
        {
            GameObject foundPlayer = FindPlayer();

            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
            else
            {
                return; // Don't proceed if still null
            }
        }

        AimAtPlayer();

        if (Time.time >= nextFireTime && currentWeapon != null)
        {
            currentWeapon.Shoot();
            nextFireTime = Time.time + fireCoolDown;
        }
    }


    void AimAtPlayer()
    {

   


         Vector3 playerPosition = player.position;
        playerPosition.z = 0f;

        // Holder position (parent of WeaponHolder)
        Vector2 holderPosition = transform.parent.position;

        Vector2 direction = (playerPosition - (Vector3)holderPosition);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the WeaponHolder to the player
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        direction = direction.normalized;

        // Keep WeaponHolder orbiting around the holder
      
        transform.position = holderPosition + direction * orbitDist;

    }



    //Just a helper function to find the player. It is not used in this script, but it can be useful for other scripts that need to find the player.
    public GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
