using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float timeToLose = 10.0f;
    [SerializeField] private int gameOverSceneIndex = 2;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Win()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}
