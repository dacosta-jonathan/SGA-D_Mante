using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChronoUI: MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] private TextMeshProUGUI chronoText;
    private float chrono = 0;

    private void Start()
    {
        chrono = gameManager.timeToLose;
    }

    void Update()
    {
        chrono -= Time.deltaTime;
        if (chrono <= 0)
        {
            chrono = 0;
            chronoText.text = chrono.ToString("0.#");
            gameManager.GameOver();
        }

        chronoText.text = chrono.ToString("0.#");
    }
}