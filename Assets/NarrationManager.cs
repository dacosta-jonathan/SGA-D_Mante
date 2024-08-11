using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrationManager : MonoBehaviour
{
    [SerializeField] AudioController audioController;

    [SerializeField]
    int nextScene;

    [SerializeField]
    List<GameObject> narrations;

    [SerializeField]
    List<int> timeStamps;

    [SerializeField]
    List<string> texts;

    [SerializeField]
    TextMeshProUGUI dialogues;

    int currentNarrationPhase;

    float counter;

    void Start()
    {
        currentNarrationPhase = 0;
        counter = 0;
        dialogues.text = texts[currentNarrationPhase];
        narrations[currentNarrationPhase].SetActive(true);
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (currentNarrationPhase < texts.Count && counter > timeStamps[currentNarrationPhase])
        {
            currentNarrationPhase += 1;
            if (currentNarrationPhase < texts.Count)
            {
                PlaySound(currentNarrationPhase);
                dialogues.text = texts[currentNarrationPhase];
                narrations[currentNarrationPhase - 1].SetActive(false);
                narrations[currentNarrationPhase].SetActive(true);
            }
        }

        if (currentNarrationPhase >= timeStamps.Count)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                audioController.PlayMusic(AudioManager.Songs.Play);
            }

            SceneManager.LoadScene(nextScene);
        }
    }

    void PlaySound(int currentNarrationPhase)
    {
        if (audioController != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                switch (currentNarrationPhase)
                {
                    case 0:
                        audioController.PlaySound(AudioManager.Effects.TalkUpF);
                        break;
                    case 1:
                        audioController.PlaySound(AudioManager.Effects.TalkDownF);
                        break;
                    case 2:
                        audioController.PlaySound(AudioManager.Effects.TalkUpF);
                        break;
                    case 3:
                        audioController.PlaySound(AudioManager.Effects.Chocked);
                        break;
                    case 4:
                        audioController.StopMusic();
                        audioController.PlaySound(AudioManager.Effects.MisterEnter);
                        break;
                    case 5:
                        audioController.PlaySound(AudioManager.Effects.TalkDownM);
                        break;
                    case 6:
                        audioController.PlaySound(AudioManager.Effects.TalkUpF);
                        break;
                }
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                switch (currentNarrationPhase)
                {
                    case 0:
                        audioController.StopMusic();
                        audioController.PlaySound(AudioManager.Effects.TalkUpM);
                        break;
                    case 1:
                        audioController.PlaySound(AudioManager.Effects.TalkDownF);
                        break;
                    case 2:
                        audioController.PlaySound(AudioManager.Effects.Bite);
                        break;
                    case 3:
                        audioController.PlayMusic(AudioManager.Songs.MainMenu);
                        break;
                }
            }
        }
    }
}
