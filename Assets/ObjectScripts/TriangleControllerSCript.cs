//This script controls the behavior of a triangle object in the game, including its health and destruction.

using UnityEngine;

public class TriangleControllerSCript : Health
{

    public float health = 50f; // Triangle health

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        
        maxHealth = health; // Set maxHealth to the value of health
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void Die()
    {
        Destroy(gameObject);

    }


   
}
