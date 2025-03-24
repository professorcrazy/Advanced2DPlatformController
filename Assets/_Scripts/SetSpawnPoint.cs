using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRespawn>()?.SetPlayerRespawn(transform.position);
        }
    }
}
