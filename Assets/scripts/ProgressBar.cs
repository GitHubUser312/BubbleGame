using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Image image;
    [SerializeField]
    public float speed = 0.2f;       // How fast the bar increases (per second)

    private float value = 0f;        // Current value (0–1)
    void Update()
    {
        speed = 1 / GameManager.Instance.MaxFreezeCoolDown;
        // Increase value over time
        value += speed * Time.deltaTime;

        // Clamp to 0–1
        value = Mathf.Clamp01(value);

        // Apply to slider
        image.fillAmount = value;
    }

    public void ResetBar()
    {
        value = 0f;
    }
}
