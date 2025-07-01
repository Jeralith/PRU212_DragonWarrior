using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [Header("UI khi hoàn thành màn")]
    public GameObject finishUI;

    public ScoreManager scoreManager;
    public TMP_Text[] counters;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            scoreManager.CalculateScore();
            scoreText.SetText("Final score: " + scoreManager.finalScore);
            highScoreText.SetText("High score: " + scoreManager.highScore);
            if (finishUI != null)
            {
                finishUI.SetActive(true);
                foreach (TMP_Text counter in counters)
                {
                    if (counter != null)
                    {
                        counter.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.LogWarning("Chưa gán FinishUI trong Inspector.");
            }

            Time.timeScale = 0f;
        }
    }
}
