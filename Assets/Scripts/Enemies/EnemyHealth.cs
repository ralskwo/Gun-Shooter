using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int max_health = 3;
    [SerializeField] ParticleSystem exlposionVFX;

    int current_health;

    GameManager gameManager;

    void Awake()
    {
        current_health = max_health;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeftUI(1);
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;

        if (current_health <= 0)
        {
            gameManager.AdjustEnemiesLeftUI(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(exlposionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
