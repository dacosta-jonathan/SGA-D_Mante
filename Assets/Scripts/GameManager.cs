using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float timeToLose = 10.0f;
    [SerializeField] private int gameOverSceneIndex = 2;
    [SerializeField] private int winSceneIndex = 3;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Win()
    {
        SceneManager.LoadScene(winSceneIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}
