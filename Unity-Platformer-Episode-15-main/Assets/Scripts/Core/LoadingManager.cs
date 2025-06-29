using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance { get; private set; }
    public string levelName;

    private void Awake()
    {
        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }

    public void LoadCurrentLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        SceneManager.LoadScene(currentLevel);
    }
    public void Restart()
    {
        //SceneManager.LoadScene(currentLevel);
    }
    public static void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public static void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}