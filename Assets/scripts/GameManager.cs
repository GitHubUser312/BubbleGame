using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winGameUI;
    public static GameManager Instance { get; private set; }
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
    public void GameOver()
    {
        winGameUI.SetActive(true);
    }
}