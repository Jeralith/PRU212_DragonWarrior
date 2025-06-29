using UnityEngine;

public class Finish : MonoBehaviour
{
    [Header("UI khi hoàn thành màn")]
    public GameObject finishUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (finishUI != null)
            {
                finishUI.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Chưa gán FinishUI trong Inspector.");
            }

            Time.timeScale = 0f;
        }
    }
}
