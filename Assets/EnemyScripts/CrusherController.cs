//This script controls the crusher enemy. It makes the crusher move back and forth along one axis, switching direction every few seconds or when it becomes aligned with the player on either axis. The crusher also has health and can damage the player on collision.

using JetBrains.Annotations;
using Mono.Cecil.Cil;
using System.Collections;
using UnityEngine;

public class CrusherController : Health
{

    public float speed = 2f; // Speed at which the crusher moves
 
    public float nextTimeToSwitch = 0f; // Time when the crusher should switch direction
    public float switchInterval = 2f; // Interval between direction switches
    private string axis = "horizontal"; // Current direction of movement ("horizontal" or "vertical")
    private float direction = 1f; // 1 for forwards, -1 for backwards
    public Transform player; // Reference to the player transform
    public float health = 200f; // Health of the crusher
    public float damage = 100f; // Damage dealt to the player on collision

    public float pauseDuration = 1.5f; // How long it waits before moving again
    private bool isPaused = false;

    public float alignmentThreshold = 0.2f;
    private bool alignedX = false; // Whether the crusher is aligned with the player on the X-axis
    private bool alignedY = false; // Whether the crusher is aligned with the player on the Y-axis

    bool wasAligned = false; // Whether the crusher was aligned with the player in the previous check



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        maxHealth = health;
        base.Start();


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

    }
    // Update is called once per frame
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
                // Player is gone -> stop behavior
                return;
            }
        }

        
            //Checks if the crusher is paused. If its paused, it does nothing. 
            if (isPaused) return;

            // Check alignment with player on both axises, utilizing a small error margin. 
            alignedX = Mathf.Abs(transform.position.x - player.position.x) < alignmentThreshold;
            alignedY = Mathf.Abs(transform.position.y - player.position.y) < alignmentThreshold;

            //If the crusher is aligned on either axis, it is considered aligned
            bool currentlyAligned = alignedX ^ alignedY;

            
            if ((currentlyAligned && !wasAligned)  || (!currentlyAligned && Time.time >= nextTimeToSwitch))
            {
                StartCoroutine(SwitchWithPause());
                nextTimeToSwitch = Time.time + switchInterval;
            }
            

            wasAligned = currentlyAligned;



            // Move the crusher in the current direction
            if (axis == "horizontal")
            {
                transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * speed * direction * Time.deltaTime);
            }






    }//End Update

    IEnumerator SwitchWithPause()
    {
        isPaused = true;

        // Stop movement during pause
        yield return new WaitForSeconds(pauseDuration);

        UpdateDirection();

        isPaused = false;
    }//End SwitchWithPause

    void UpdateDirection()
    {


        if (player==null) return;


        float vertdistance = Mathf.Abs(transform.position.y - player.position.y);
        float horidistance = Mathf.Abs(transform.position.x - player.position.x);
        
        if (alignedX ^ alignedY)
        {

            Debug.Log("aligned");
            if (alignedX)
            {
                axis = "vertical"; 
                
            }
            else if (alignedY)
            {
                axis = "horizontal";

            }//End If
        }
        else
        {

            Debug.Log("wasn't aligned this time");


            if (vertdistance <= horidistance)
            {
                axis = "horizontal";
            }
            else
            {
                axis = "vertical";
            }//End If

           

        }//End If

        if (axis == "horizontal")
        {
            direction = (player.position.x > transform.position.x) ? 1f : -1f;
        }
        else
        {
            direction = (player.position.y > transform.position.y) ? 1f : -1f;
        }//End If



        Debug.Log("Switched!");

    }//End UpdateDirection


    protected override void Die()
    {
        Destroy(gameObject);
    }//End Die

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.LogWarning("Normal Bullet: I just hit '{collision.gameObject.name}'");
        // Check if the collided object has a health component


        Health health = other.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);

        }//End If

    }//End OnTriggerEnter2D


    public GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }//End FindPlayer
}

