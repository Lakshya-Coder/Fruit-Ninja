using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver Elements")]
    public GameObject gameOverPanel;

    [Header("Sounds")]
    public AudioSource gameOverSound;
    public AudioSource startSound;

    private void Start()
    {
        GetHighScore();
        startSound.Play();
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            SetHighScore();
            highScoreText.text = "Best: " + highScore.ToString();
        }
    }

    public void PlaySliceSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        if (!gameOverSound.isPlaying)
        {
            gameOverSound.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void SetHighScore() {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highScore.ToString();
    }
}