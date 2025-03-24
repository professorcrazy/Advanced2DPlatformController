using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector3 spawnPoint = Vector3.zero;
    public void SetPlayerRespawn(Vector3 point)
    {
        spawnPoint = point;
    }

    public void RewpawnPlayer()
    {
        transform.position = spawnPoint;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}
