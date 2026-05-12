//This script makes the camera follow the player by updating its position to match the player's position while keeping the camera's z-axis unchanged.

using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject target;






    void Start()
    {
   
    }

    // Update is called once per frame
    void Update() 
    {
        if (target != null)
        {
            Vector3 newPosition = target.transform.position;
            newPosition.z = transform.position.z; // Keep the camera's z position unchanged
            transform.position = newPosition;
        }
    }
}
