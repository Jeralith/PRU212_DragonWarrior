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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
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
    public void LoadMenuScene() => SceneManager.LoadScene("_Menu");

    

    public void Quit() => Application.Quit();
    
}