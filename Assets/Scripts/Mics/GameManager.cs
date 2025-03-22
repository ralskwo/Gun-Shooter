using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinUI;
    [SerializeField] Transform pauseUI;

    int enemiesLeft = 0;


    StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void AdjustEnemiesLeftUI(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = $"Enemies Left: {enemiesLeft}";

        if (enemiesLeft <= 0)
        {
            youWinUI.SetActive(true);
        }
    }

    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            starterAssetsInputs.SetCursorState(false);
            pauseUI.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            starterAssetsInputs.SetCursorState(false);
            pauseUI.gameObject.SetActive(false);
        }
    }
}
