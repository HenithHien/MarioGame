using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text =score.ToString();
    }
}
