//Scriptable object class for spawnable objects. 

using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableObjects", menuName = "Spawnable Object")]
public class SpawnableObjects : ScriptableObject
{
    public string name;
    public GameObject prefab;
}
