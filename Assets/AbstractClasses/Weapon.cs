//Abstract class for weapons. Each weapon will have its own implementation of the Shoot method.
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Shoot();
}

