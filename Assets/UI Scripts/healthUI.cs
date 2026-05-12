using UnityEngine;
using TMPro; // if using TextMeshPro

public class HealthUI : MonoBehaviour
{
    public Health playerHealth;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = playerHealth.currentHealth + " / " + playerHealth.maxHealth;
    }
}
