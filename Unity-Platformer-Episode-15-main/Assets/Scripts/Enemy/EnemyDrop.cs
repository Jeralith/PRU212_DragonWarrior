using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [Header("Coin drop settings")]
    public GameObject coinPrefab;
    public int minCoins = 1;
    public int maxCoins = 3;

    [Header("Force settings")]
    public float upwardForce = 5f;
    public float horizontalForce = 2f;

    public void DropCoins()
    {
        int coinAmount = Random.Range(minCoins, maxCoins + 1);

        for (int i = 0; i < coinAmount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float randomX = Random.Range(-horizontalForce, horizontalForce);
                rb.AddForce(new Vector2(randomX, upwardForce), ForceMode2D.Impulse);
            }
        }
    }
}
