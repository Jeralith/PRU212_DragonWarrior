using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance { get; private set; }
    public string levelName;
    public GameObject mainMenu;
    public GameObject levelSelectUI;
    public GameObject finishUI;
    private void Awake()
    {
        if (finishUI != null)
        {
            finishUI.SetActive(false);
        }
        OpenMainMenu();
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
        //int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Restart()
    {
        //SceneManager.LoadScene(currentLevel);
    }
    public static void LoadLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public static void LoadLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");
    }

    public void OpenLevelSelect()
    {
        if (levelSelectUI != null && mainMenu != null)
        {
            levelSelectUI.SetActive(true);
            mainMenu.SetActive(false);
        }

    }
    public void OpenMainMenu()
    {
        Time.timeScale = 1;

        if (levelSelectUI != null && mainMenu != null)
        {
            levelSelectUI.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("_Menu");

    }

    public void Quit()
    {
        Application.Quit();
    }
}