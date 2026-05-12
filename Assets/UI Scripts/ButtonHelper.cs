using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    //This is the desired object.
    public SpawnableObjects data;

    //This is the panel. 
    public SpawnMenuManager menu;

    void Start()
    {

        //Just makes a listener for the button so it knows when its clicked. 
        GetComponent<Button>().onClick.AddListener(() =>
        {
            //the button's data (the prefab)
            menu.SelectObject(data);
        });
    }
}