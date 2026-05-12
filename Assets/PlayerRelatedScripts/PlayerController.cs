//This script controls the player character. It handles movement, health, and weapon management. The player can walk and run using the WASD keys and Left Shift key. The player has a health system that allows them to take damage and die when health reaches zero. The player can also equip weapons and shoot them using the mouse button.

using UnityEngine;

public class PlayerController : Health
{
    const float walkSpeed = 5f; // Default move speed for the player
    const float runSpeed = 10f; // Default move speed for the player
    public float moveSpeed;
    public Weapon[] weapons = new Weapon[4]; // Array to hold the player's weapons, can be set in the inspector

    public bool isDead = false; // Flag to track if the player is dead
    private Vector2 deathPosition; // Position where the player died, used for respawning


    private Rigidbody2D rb;
    private Vector2 movement;

    public WeaponBaseController weaponBase; // Reference to the WeaponBaseController component
    public float health = 100f; // How much health player has

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        maxHealth = health; // Set maxHealth to the value of health
        currentHealth = maxHealth;
        base.Start();



        Debug.Log("Weapons array length: " + weapons.Length);

        for (int i = 0; i < weapons.Length; i++)
        {
            Debug.Log("Weapon " + i + ": " + weapons[i]);
        }

      
    }

  


    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }

            return; // Stop all other input while dead
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("HE BE RUNNIN!!!!!");
                moveSpeed = runSpeed; // Double the move speed when Left Shift is pressed

            }
            else
            {
                moveSpeed = walkSpeed; // Reset the move speed when Left Shift is released
            }

            movement = movement.normalized;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {


                weaponBase.EquipWeapon(weapons[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                weaponBase.EquipWeapon(weapons[1]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                weaponBase.EquipWeapon(weapons[2]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                weaponBase.EquipWeapon(weapons[3]);
            }

        }

           
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    protected override void Die()
    {
        isDead = true;

        // Save where player died
        deathPosition = transform.position;

        // Stop movement
        rb.linearVelocity = Vector2.zero;

        Debug.Log("Player died! Press R to respawn.");
    }

    void Respawn()
    {
        isDead = false;

        // Restore health
        currentHealth = maxHealth;

        // Respawn at death position
        transform.position = deathPosition;

        Debug.Log("Player respawned!");
    }
}
