using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public int maxHP = 100;
    private int hp = 100;
    float damageDelay = 0.25f;
    float lastDamage = 0f;
    bool canTakeDamage = true;
    private void Start()
    {
        InitiatePlayerHealth();
    }

    public void InitiatePlayerHealth()
    {
        hp = maxHP;
        lastDamage = Time.timeSinceLevelLoad;
        canTakeDamage = true;
    }
    public void TakeDamage(int dmg)
    {
        if (!canTakeDamage)
        {
            return;
        }
        

        hp -= dmg;
        if (hp <= 0)
        {
            canTakeDamage = false;
            StartCoroutine(DamageCooldown(damageDelay));
            if (HealthVisualizer.Instance.LoseLife() && canTakeDamage) { 
                Debug.Log("Died at: " + Time.timeAsDouble);
                GetComponent<PlayerRespawn>()?.RewpawnPlayer();
                InitiatePlayerHealth();
            }
        }
    }
    IEnumerator DamageCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canTakeDamage = true;
    }
}