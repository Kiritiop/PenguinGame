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
}
