using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;
    public static ScoreManager Instance { get; private set; }

    private int currentScore;
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
