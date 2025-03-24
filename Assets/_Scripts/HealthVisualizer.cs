using UnityEngine;
using UnityEngine.UI;

public class HealthVisualizer : MonoBehaviour
{
    public static HealthVisualizer Instance;
    [SerializeField] Image[] heartIcons;
    int livesLeft;
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
        if (livesLeft < 0)
        {
            MenuController.Instance.LoseGame();
            return false;
        }
        heartIcons[livesLeft].color = Color.black;
        return true;

    }
}
