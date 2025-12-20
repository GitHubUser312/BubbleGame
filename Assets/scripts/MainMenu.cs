using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator fader;
    public void Play()
    {
        StartCoroutine(OpenLevel());
    }
    // Update is called once per frame
    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator OpenLevel()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator QuitGame()
    {
        fader.SetBool("transition", true);
        yield return new WaitForSeconds(1);
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
