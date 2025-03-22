using Cinemachine.Utility;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] GameObject projectileHitVFX;
    [SerializeField] AudioClip projectileHitSFX;

    Rigidbody rb;


    int damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        PlayHitSound();
        Instantiate(projectileHitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void PlayHitSound()
    {
        GameObject tempAudio = new GameObject("ProjectileHitSound");
        AudioSource tempSource = tempAudio.AddComponent<AudioSource>();

        tempSource.clip = projectileHitSFX;
        tempSource.volume = 1f;
        tempSource.playOnAwake = false;
        tempSource.loop = false;
        tempSource.spatialBlend = 0f;

        tempSource.Play();
        Destroy(tempAudio, projectileHitSFX.length);
    }
}
