using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;

    public static ScoreManager Instance { get; private set; }

    // Current Score
    public int currentScore;

    public int CurrentScore { get { return currentScore; } }

    // High Score
    public int highScore;

    public int HighScore { get { return highScore; } }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        scoreTxt.text = "Score: " + currentScore;
        highScoreTxt.text = "High Score: " + PlayerPrefs.GetInt("HighScore");

        // Load high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreTxt.text = "Score: " + currentScore;

        // Check for new high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreTxt.text = "High Score: " + highScore;
    }

}
