using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisualizer : MonoBehaviour
{
    public static HealthVisualizer Instance;
    [SerializeField] Image[] heartIcons;
    int livesLeft;
    [SerializeField] float loseGameDelay = 1.2f;
    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        ResetHealth();
    }

    public void ResetHealth()
    {
        livesLeft = heartIcons.Length;
        for (int i = 0; i < livesLeft; i++)
        {
            heartIcons[i].color = Color.red;
        }
    }
    public bool LoseLife()
    {
        livesLeft--;
        if (livesLeft >= 0)
            heartIcons[livesLeft].color = Color.black;
        if (livesLeft <= 0)
        {
            StartCoroutine(LoseGameDelay(loseGameDelay));
            return false;
        }
        return true;
    }

    IEnumerator LoseGameDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MenuController.Instance.LoseGame();
    }
}
