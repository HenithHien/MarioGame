using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameUIManager uiManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Debug.Log("Player took damage! Current HP: " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");

        // Gọi UI Game Over
        if (uiManager != null)
        {
            
            uiManager.ShowGameOver();
        }
        AudioManager.Instance.StopAllEffects();
        // Tắt di chuyển của player
        var moveScript = GetComponent<PlayerController>(); 
        if (moveScript != null)
        {
            moveScript.enabled = false;
        }
    }
    public int get => currentHealth;
}
