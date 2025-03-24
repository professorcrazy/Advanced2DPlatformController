using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{
    public Transform player;
    public bool followPlayer = false;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            transform.position = player.position;

        }
    }
}
