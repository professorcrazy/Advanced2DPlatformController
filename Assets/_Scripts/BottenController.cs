using UnityEngine;

public class BottenController : MonoBehaviour
{
    [SerializeField] AttachToPlayer anchorToPlayer;
    [SerializeField] GameObject finishedPrefab;
    [SerializeField] SpriteRenderer ropeRenderer;
    bool connected = false;

    private void Start()
    {
        ropeRenderer.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!connected)
        {
            if (other.CompareTag("Player"))
            {
                connected = true;
                ropeRenderer.enabled = true;
                anchorToPlayer.player = other.transform;
                anchorToPlayer.followPlayer = true;
            }
        }
        if (other.CompareTag("Finish"))
        {
            Instantiate(finishedPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(ropeRenderer.gameObject);
        }
    }
}
