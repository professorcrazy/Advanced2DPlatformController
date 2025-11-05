using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    private int score = 0;
    TMPro.TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null) {
            Destroy(this);
            return;
        }
        instance = this;
        scoreText = GetComponent<TMPro.TMP_Text>();
        ResetScore();
        scoreText.text = "idot";
    }

    public void ResetScore() {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore(int points) {
        score += points;
        scoreText.text = score.ToString();
    }

}
