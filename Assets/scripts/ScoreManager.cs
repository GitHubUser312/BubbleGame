using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;
    public static ScoreManager Instance { get; private set; }

    // Current Score
    private int currentScore;

    // High Score
    private int highScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(int amount)
    {
        currentScore += amount;
        highScore = currentScore;
        UpdateScore();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "High Score: " + highScore;
        }
    }

    void UpdateScore()
    {
        scoreTxt.text = "Score: " + currentScore;
        highScoreTxt.text = "HighScore: " + highScore;
    }
}
