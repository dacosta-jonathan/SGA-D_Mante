using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] int mainMenuSceneIndex = 2;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
