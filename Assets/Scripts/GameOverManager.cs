using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] int mainMenuSceneIndex = 0;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
