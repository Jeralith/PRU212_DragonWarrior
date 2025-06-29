using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("UI")]
    public TMP_Text coinText;
    public AudioClip coinSFX;

    private int coinCount = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        SoundManager.instance.PlaySound(coinSFX);
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.SetText($"Coins: {coinCount}");
    }
}
