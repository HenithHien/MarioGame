using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;
    private bool hasTriggeredPhase2 = false;
    private AudioSource audioSource;
    public AudioClip winSound;

    public delegate void Phase2Triggered();
    public event Phase2Triggered OnPhase2;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Gọi phase 2 nếu máu <= 100 và chưa gọi lần nào
        if (!hasTriggeredPhase2 && currentHealth <= 100)
        {
            hasTriggeredPhase2 = true;
            OnPhase2?.Invoke();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindAnyObjectByType<GameUIManager>().ShowGameWin();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
