using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winGameUI;
    public GameObject bigBubble;
    public ProgressBar progressBar;
    public static GameManager Instance { get; private set; }

    // Global delta time accessible for other scripts // not yet implemented
    public static float GlobalDelta { get; private set;  }
    // Global delta time as int (for testing purposes) // not yet implemented
    public static int GlobalDeltaInt { get; private set; }
    [SerializeField]
    private float maxFreezeCoolDown = 6.0f;
    public float MaxFreezeCoolDown { get { return maxFreezeCoolDown; } }

    private void Update()
    {
        GlobalDelta += Time.deltaTime;
        GlobalDeltaInt = (int)GlobalDelta;

        // random line
        Debug.DrawLine(Vector3.zero, Vector3.one * 10, Color.red);
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void GameOver()
    {
        if (winGameUI != null)
        {
            winGameUI.SetActive(true);
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