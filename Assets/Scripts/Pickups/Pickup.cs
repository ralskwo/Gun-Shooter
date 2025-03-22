using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float bobbingSpeed = 4f;
    [SerializeField] float bobbingHeight = 0.2f;
    [SerializeField] AudioClip pickupSound;

    const string PLAYER_STRING = "Player";

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 bobbing = new Vector3(0, Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight, 0);
        transform.position += bobbing * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);

            PlayPickupSound();
            Destroy(gameObject);
        }
    }

    private void PlayPickupSound()
    {
        GameObject tempAudio = new GameObject("PickupSound");
        AudioSource tempSource = tempAudio.AddComponent<AudioSource>();

        tempSource.clip = pickupSound;
        tempSource.volume = 1f;
        tempSource.playOnAwake = false;
        tempSource.loop = false;
        tempSource.spatialBlend = 0f;

        tempSource.Play();
        Destroy(tempAudio, pickupSound.length);
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
