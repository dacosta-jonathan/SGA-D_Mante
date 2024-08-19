using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] int mainMenuSceneIndex = 0;
    [SerializeField] AudioController audioController;


    public void LoadMainMenu()
    {
        audioController.PlayMusic(AudioManager.Songs.MainMenu);
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
