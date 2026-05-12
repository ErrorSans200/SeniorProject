//This script controls the circle enemy. It has health and can be damaged by the player. When it dies, it is destroyed. 
using UnityEngine;

public class EnemyCircleController : Health
{

    public float health = 100f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        maxHealth = health;
        base.Start();



    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

}
