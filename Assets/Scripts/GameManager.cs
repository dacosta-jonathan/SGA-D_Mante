using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float timeToLose = 10.0f;
    [SerializeField] private int gameOverSceneIndex = 3;
    [SerializeField] private int winSceneIndex = 4;
    [SerializeField] AudioController audioController;

    public void Win()
    {
        if (audioController != null)
        {
            audioController.StopMusic();
            audioController.PlaySound(AudioManager.Effects.Cashing);
        }
        SceneManager.LoadScene(winSceneIndex);
    }

    public void GameOver()
    {
        if (audioController != null)
        {
            audioController.StopMusic();
            audioController.PlaySound(AudioManager.Effects.Thunder);
        }
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}
