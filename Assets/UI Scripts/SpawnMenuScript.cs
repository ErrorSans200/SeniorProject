using UnityEngine;
using UnityEngine.EventSystems;


public class SpawnMenuScript : MonoBehaviour
{

    public GameObject menuPanel; //This is the thing that will pop up when you press the button. It should be a panel with buttons on it

    void Start()
    {
        menuPanel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            bool isActive = !menuPanel.activeSelf;
            menuPanel.SetActive(isActive);


        }
    }
}
