using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CoinManager.instance.AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
