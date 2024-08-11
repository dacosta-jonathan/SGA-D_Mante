using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class AudioController : MonoBehaviour
{
    AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindFirstObjectByType<AudioManager>();
    }

    public void PlayMusic(AudioManager.Songs song)
    {
        if (manager != null)
        {
            manager.PlayMusic(song);
        }
    }

    public void StopMusic()
    {
        if (manager != null)
        {
            manager.StopMusic();
        }
    }

    public void PlaySound(int type)
    {
        if (manager != null)
        {
            manager.PlaySound((AudioManager.Effects)type);
        }
    }
    public void PlaySound(AudioManager.Effects type)
    {
        if (manager != null)
        {
            manager.PlaySound(type);
        }
    }

}
