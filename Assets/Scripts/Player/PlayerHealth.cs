using Cinemachine;
using UnityEngine.UI;
using UnityEngine;
using System;
using StarterAssets;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int max_health = 5;
    [SerializeField] CinemachineVirtualCamera deathCam;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Image hitScreen;

    int current_health;
    int gameOverVirtualCameraPriority = 20;

    CinemachineImpulseSource impulseSource;

    void Awake()
    {
        current_health = max_health;
        impulseSource = GetComponent<CinemachineImpulseSource>();
        AdjustShieldUI();
    }

    public void TakeDamage(int amount)
    {
        current_health -= amount;
        impulseSource.GenerateImpulse();
        AdjustShieldUI();
        StartCoroutine(FadeHitScreen());

        if (current_health <= 0)
        {
            PlayerGameOver();
        }
    }

    IEnumerator FadeHitScreen()
    {
        Color hitColor = hitScreen.color;
        hitColor.a = 0.8f;
        hitScreen.color = hitColor;

        float duration = 1.0f; // Duration of the fade
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            hitColor.a = Mathf.Lerp(0.8f, 0f, elapsedTime / duration);
            hitScreen.color = hitColor;
            yield return null;
        }

        hitColor.a = 0f;
        hitScreen.color = hitColor;
    }

    private void PlayerGameOver()
    {
        weaponCamera.parent = null;
        deathCam.Priority = gameOverVirtualCameraPriority;
        gameOverUI.SetActive(true);
        hitScreen.gameObject.SetActive(false);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(gameObject);
    }

    private void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < current_health)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
