using UnityEngine;

public class MenuSceneSetup : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject levelSelectUI;

    void Start()
    {
        if (LoadingManager.instance != null)
        {
            LoadingManager.instance.mainMenu = mainMenuUI;
            LoadingManager.instance.levelSelectUI = levelSelectUI;

            // Optional: đảm bảo về trạng thái MainMenu khi load scene
            LoadingManager.instance.OpenMainMenu();
        }
    }
}
