using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public int maxHP = 100;
    private int hp = 100;

    private void Start()
    {
        InitiatePlayerHealth();
    }

    public void InitiatePlayerHealth()
    {
        hp = maxHP;
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            if (HealthVisualizer.Instance.LoseLife()) { 
                GetComponent<PlayerRespawn>()?.RewpawnPlayer();
                InitiatePlayerHealth();
            }
        }
    }
}
