using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Thời gian cho phép (giây)")]
    public float time = 60f;

    [Header("Âm thanh Game Over")]
    public AudioClip gameOverSound;

    [Header("Player")]
    public GameObject player;

    public TMP_Text timeUI;

    public float currentTime;
    private bool isRunning = false;
    private UIManager uiManager;
    private Animator playerAnimator;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }

        StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        timeUI.SetText($"Time remaining: {currentTime:F2}");

        if (currentTime <= 0f)
        {
            player.GetComponent<PlayerMovement>().canMove = false;
            currentTime = 0f;
            timeUI.SetText($"Time remaining: {currentTime:F2}");
            isRunning = false;
            TriggerGameOver();
        }
    }

    public void StartTimer()
    {
        currentTime = time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void TriggerGameOver()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("die");
            StartCoroutine(DisablePlayerAfterDelay(1f));
        }
        else
        {
            Debug.LogWarning("Player Animator không tìm thấy.");
            if (player != null) player.SetActive(false);
        }

        // if (SoundManager.instance != null && gameOverSound != null)
        // {
        //     SoundManager.instance.PlaySound(gameOverSound);
        // }

        if (uiManager != null)
        {
            uiManager.GameOver();
        }
    }

    private IEnumerator DisablePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (player != null)
        {
            player.SetActive(false);
        }
    }
}
