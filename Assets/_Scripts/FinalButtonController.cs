using UnityEngine;

public class FinalButtonController : MonoBehaviour
{
    static FinalButtonController instance;

    [SerializeField] float winDelay = 2f;
    float duration = 0f;
    bool won;
    SpriteRenderer renderer;
    [SerializeField] Color startColor, winColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !won)
        {
            duration += Time.deltaTime;
            renderer.color = Color.Lerp(startColor, winColor, duration/winDelay);
            if (duration > winDelay )
            {
                won = true;
                MenuController.Instance.WinGame();
            }
        }
    }

}
