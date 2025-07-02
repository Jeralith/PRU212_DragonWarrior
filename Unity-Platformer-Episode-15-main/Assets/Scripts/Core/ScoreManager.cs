using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TimeManager timeManager;
    public CoinManager coinManager;
    public Health health;
    [Header("Score System")]
    [SerializeField] private int timeScoreMultiplier = 30;
    [SerializeField] private int coinScoreMultiplier = 500;
    [SerializeField] private int healthScoreMultiplier = 500;

    [Header("Score")]
    public int timeScore;
    public int coinScore;
    public int healthScore;
    public int finalScore;
    public int highScore = 0;
    private string levelScoreName;
    void Awake()
    {
        levelScoreName = SceneManager.GetActiveScene().name + "Score";
        if (!PlayerPrefs.HasKey(levelScoreName)) PlayerPrefs.SetInt(levelScoreName, 0);
        //"Level1Score" = 0
    }
    public void CalculateScore()
    {
        timeScore = Mathf.FloorToInt(timeManager.currentTime * timeScoreMultiplier);
        coinScore = coinManager.coinCount * coinScoreMultiplier;
        healthScore = Mathf.FloorToInt(health.currentHealth * healthScoreMultiplier);

        finalScore = timeScore + coinScore + healthScore;

        int savedHighScore = PlayerPrefs.GetInt(levelScoreName);
        if (finalScore > savedHighScore)
        {
            PlayerPrefs.SetInt(levelScoreName, finalScore);
            PlayerPrefs.Save();
        }

        highScore = Mathf.Max(savedHighScore, finalScore);
    }
}
