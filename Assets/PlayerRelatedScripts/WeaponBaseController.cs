//This script controls the player's weapon. It makes the weapon rotate around the player and shoot towards the mouse position when the left mouse button is clicked. The weapon will only shoot if the mouse is not over a UI element.


using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponBaseController : MonoBehaviour
{
    internal Weapon currentWeapon;
    public float orbitDist = 1.0f; //This tell thing how far it is from player. 
    private Camera cam;

    private PlayerController player; // Reference to player


    void Start()
    {
        // Get player from parent
        player = GetComponentInParent<PlayerController>();

        // Only run setup if player is alive
        if (!player.isDead)
        {
            currentWeapon = GetComponentInChildren<Weapon>();
            cam = Camera.main;
        }
    }


    void RotateToMouse()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Player position (parent of WeaponHolder)
        Vector2 playerPosition = transform.parent.position;

        Vector2 direction = (mousePosition - (Vector3)playerPosition);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the WeaponHolder 
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        direction = direction.normalized;

        // Keep WeaponHolder orbiting around player
        transform.position = playerPosition + direction * orbitDist;
    }

    void Update()
    {

        if (player.isDead)
        {
            return;
        }

        RotateToMouse();

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (currentWeapon != null)
            {

               currentWeapon.Shoot();




            }
        }
    }

    public void EquipWeapon(Weapon weaponPrefab)
    {
        // Remove old weapon
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        // Create new weapon as child of holder
        Weapon newWeapon = Instantiate(weaponPrefab, transform.position, transform.rotation, transform);

        currentWeapon = newWeapon;
    }
}