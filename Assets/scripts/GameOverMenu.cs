using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] Animator fader;

    public void Restart()
    {
        StartCoroutine(RestartGame());
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator RestartGame()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator QuitGame()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
