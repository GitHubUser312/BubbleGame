using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject warning; // apparently is null
    public GameObject bigBubble;
    public ProgressBar progressBar;
    public static GameManager Instance { get; private set; }

    // Global delta time accessible for other scripts // not yet implemented
    public static float GlobalDelta { get; private set;  }
    // Global delta time as int (for testing purposes) // not yet implemented
    public static int GlobalDeltaInt { get; private set; }
    [SerializeField]
    private float maxFreezeCoolDown = 10;
    public float MaxFreezeCoolDown { get { return maxFreezeCoolDown; } }

    private float countdownToEndGame = 10.0f;
    public float CountdownToEndGame { get { return countdownToEndGame; } }

    private int numOfEnemies = 0;
    public int NumOfEnemies { get { return numOfEnemies; } set { numOfEnemies = value; } }

    public bool IsGameOver { get; private set; } = false; // for the player controller

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Update()
    {
        GlobalDelta += Time.deltaTime;
        GlobalDeltaInt = (int)GlobalDelta;
        
        // countdown
        if (numOfEnemies > 50)
        {
            countdownToEndGame -= Time.deltaTime;
            if(warning != null)
            {
                warning.SetActive(true);
                warning.GetComponent<TextMeshProUGUI>().text = "WARNING: No more than 50 bubbles, ending player in " + ((int)countdownToEndGame).ToString() + "s !";
            }
        }
        else if (numOfEnemies <= 50)
        {
            countdownToEndGame = 10.0f;
            if (warning != null)
            {
                warning.SetActive(false);
            }
        }

        if (countdownToEndGame <= 0)
        {
            IsGameOver = true; // The player controller will call GameOver()
        }

    }

    public void GameOver()
    {
        if (gameOverUI != null && scoreUI != null)
        {
            gameOverUI.SetActive(true);
            scoreUI.SetActive(false);
        }


        if (bigBubble != null)
        {
            var spawner = bigBubble.GetComponent<EnemySpawner>();

            if (spawner != null)
            {
                spawner.enabled = false;
            }
        }

    }
}