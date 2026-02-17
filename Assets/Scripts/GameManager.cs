using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject PauseMenu;


    public static bool IsPaused = false;

    private int score = 0;
    private bool isGameOver = false;
    public float baseSpeed = 5f;
    public float speedIncreaseRate = 0.15f; 

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false);
        PauseMenu.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        PauseMenu.SetActive(false);
        IsPaused = false;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                GameResume();
            }

            else
            {
                GamePause();
            }
            
        }
    }

    public void GamePause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

    }

    public void GameResume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

    }
    public float GetCurrentSpeed()
    {
        return baseSpeed + (Time.timeSinceLevelLoad * speedIncreaseRate);
    }
}
