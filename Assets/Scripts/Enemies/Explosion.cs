using UnityEditor;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in colliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            if (!playerHealth) continue;

            playerHealth.TakeDamage(damage);
            gameManager.AdjustEnemiesLeftUI(-1);

            break;
        }
    }
}
