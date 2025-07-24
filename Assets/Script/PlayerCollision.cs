using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private AudioSource audioSource;

    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        playerHealth = GetComponent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            AudioManager.Instance.PlayCoin();
            Destroy(collision.gameObject);
            gameManager.AddScore(1);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy!");
            GetComponent<PlayerController>().HurtPlayer();
            playerHealth.TakeDamage(10);
            
        }
        else if (collision.CompareTag("Key"))
        {

            Debug.Log("Player collected the key — WIN!");
            
            Destroy(collision.gameObject);
            FindAnyObjectByType<GameUIManager>().ShowGameWin();
            
            
        }
        // Thêm xử lý cho EnemyBullet và BossBullet
        else if (collision.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player collided with bbullet!");
            GetComponent<PlayerController>().HurtPlayer();
            playerHealth.TakeDamage(10); // hoặc lấy damage từ script đạn nếu muốn
            // Nếu muốn đạn tự hủy khi trúng player:
            Destroy(collision.gameObject);
            
        }
        // Thêm xử lý cho Boss (nếu muốn boss chạm vào là mất máu)
        else if (collision.CompareTag("Boss"))
        {
            Debug.Log("Player collided with Boss!");
            GetComponent<PlayerController>().HurtPlayer();
            playerHealth.TakeDamage(10); // hoặc damage khác nếu muốn
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Player collided with trap!");
            GetComponent<PlayerController>().HurtPlayer();
            playerHealth.TakeDamage(5);
            
        }
        else if (collision.gameObject.CompareTag("DieTrap"))
        {
            Debug.Log("Player collided with trap!");
            GetComponent<PlayerController>().HurtPlayer();
            playerHealth.TakeDamage(100);
            
        }
    }
}
