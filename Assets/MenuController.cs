using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] int LevelSceneIndex = 1;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(LevelSceneIndex);
    }
}
