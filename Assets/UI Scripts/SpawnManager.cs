// Hate. Let me tell you how much Ive come to hate you since I began to live. There are 5 million miles of



using UnityEngine;

public class SpawnMenuManager : MonoBehaviour
{
    //whole array of spawnables
    public SpawnableObjects[] spawnables;

    //selected spawnable
    public SpawnableObjects selected;

    public void SelectObject(SpawnableObjects obj)
    {
       //outputs log (helpful)
        selected = obj;
        Debug.Log("Selected: " + obj.name);
    }
}