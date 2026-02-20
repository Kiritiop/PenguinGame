using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string savePath;
    private int highScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject PauseMenu;
    public TextMeshProUGUI gameOverScoreText; 


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
        savePath = Application.persistentDataPath + "/highscore.json";

        LoadHighScore();

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
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }

        gameOverPanel.SetActive(true);

        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + score + "\nHigh Score: " + highScore;
        }

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
    void LoadHighScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            highScore = data.highScore;
        }
        else
        {
            highScore = 0;
        }
    }

    void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }
}
