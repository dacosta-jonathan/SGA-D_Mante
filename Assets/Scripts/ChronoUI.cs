using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChronoUI: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronoText;
    [SerializeField] private float timeToLose = 120.0f;
    [SerializeField] private int gameOverSceneIndex = 1;
    private float chrono = 0;

    private void Awake()
    {
        chrono = timeToLose;
    }

    void Update()
    {
        chrono -= Time.deltaTime;
        if (chrono <= 0)
        {
            chrono = 0;
            chronoText.text = chrono.ToString("0.#");
            GameOver();
        }

        chronoText.text = chrono.ToString("0.#");
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}