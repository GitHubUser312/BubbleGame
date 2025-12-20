using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] Animator fader;

    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    public void Restart()
    {
        StartCoroutine(RestartGame());
    }

    private void OnEnable()
    {
        scoreTxt.text = "CurrentScore: " + ScoreManager.Instance.currentScore;
        highScoreTxt.text = "CurrentScore: " + ScoreManager.Instance.highScore;
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator RestartGame()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator QuitGame()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
