using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;
    public static ScoreManager Instance { get; private set; }

    private int currentScore;
    public int CurrentScore { get { return currentScore; } }
    private int highScore;
    public int HighScore { get { return highScore; } }

    public void IncrementScore()
    {
        ++currentScore;
        scoreTxt.text = "Score: " + currentScore;
        Debug.Log("Score: " + currentScore);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        scoreTxt = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }
    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
