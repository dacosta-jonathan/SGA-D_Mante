using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] int LevelSceneIndex = 1;
     [SerializeField] private int ruleSceneIndex = 6;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(LevelSceneIndex);
    }

    public void Rule()
    {
        
        SceneManager.LoadScene(ruleSceneIndex);
    }
}
