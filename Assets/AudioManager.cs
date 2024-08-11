using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainMenuSong;
    [SerializeField] AudioClip PlaySong;
    [SerializeField] AudioClip Bird;


    [SerializeField] AudioClip ButtonPress;
    [SerializeField] AudioClip ButtonStart;

    [SerializeField] AudioClip MenuDeplacement;
    [SerializeField] AudioClip Wound;

    [SerializeField] AudioClip Collect;
    [SerializeField] AudioClip Walk;
    [SerializeField] AudioClip Thunder;
    [SerializeField] AudioClip Cashing;
    [SerializeField] AudioClip Rain;

    [SerializeField] AudioClip Chocked;
    [SerializeField] AudioClip Bite;
    [SerializeField] AudioClip TalkUpF;
    [SerializeField] AudioClip TalkDownF;
    [SerializeField] AudioClip MisterEnter;
    [SerializeField] AudioClip TalkUpM;
    [SerializeField] AudioClip TalkDownM;

    public enum Songs
    {
        MainMenu,
        Play,
        Bird,
    }

    public enum Effects
    {
        ButtonPress,
        ButtonStart,
        MenuDeplacement,

        Wound,
        Collect,
        Walk,
        Thunder,
        Cashing,
        Rain,

        Chocked,
        Bite,
        TalkUpF,
        TalkDownF,
        MisterEnter,
        TalkUpM,
        TalkDownM,
    }

    AudioSource music;
    List<AudioSource> Sounds;
    [SerializeField] int numberOfSoundMax = 16;
    // Start is called before the first frame update

    private void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        music = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        music.clip = mainMenuSong;
        music.Play();
        music.loop = true;

        Sounds = new List<AudioSource>();
        for (int i = 0; i < numberOfSoundMax; i++)
        {
            Sounds.Add(gameObject.AddComponent(typeof(AudioSource)) as AudioSource);
            Sounds[i].loop = false;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(Songs type)
    {
        AudioClip song = null;
        switch (type)
        {
            case Songs.MainMenu:
                song = mainMenuSong;
                break;
            case Songs.Play:
                song = PlaySong;
                break;
            case Songs.Bird:
                song = Bird;
                break;
        }
        music.clip = song;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlaySound(Effects type)
    {
        AudioClip sound = null;
        switch (type)
        {
            case Effects.ButtonPress:
                sound = ButtonPress;
                break;
            case Effects.ButtonStart:
                sound = ButtonStart;
                break;
            case Effects.Collect:
                sound = Collect;
                break;
            case Effects.MenuDeplacement:
                sound = MenuDeplacement;
                break;
            case Effects.Walk:
                sound = Walk;
                break;
            case Effects.Wound:
                sound = Wound;
                break;
            case Effects.Thunder:
                sound = Thunder;
                break;
            case Effects.Cashing:
                sound = Cashing;
                break;
            case Effects.Rain:
                sound = Rain;
                break;
            case Effects.Chocked:
                sound = Chocked;
                break;
            case Effects.Bite:
                sound = Bite;
                break;
            case Effects.TalkUpF:
                sound = TalkUpF;
                break;
            case Effects.TalkDownF:
                sound = TalkDownF;
                break;
            case Effects.MisterEnter:
                sound = MisterEnter;
                break;
            case Effects.TalkUpM:
                sound = TalkUpM;
                break;
            case Effects.TalkDownM:
                sound = TalkDownM;
                break;
        }

        AudioSource soundAudio = GetSoundAudio();
        if (soundAudio != null)
        {
            soundAudio.clip = sound;
            soundAudio.Play();
        }
    }

    private AudioSource GetSoundAudio()
    {
        AudioSource soundAudio = null;
        foreach (AudioSource audio in Sounds)
        {
            if (!audio.isPlaying)
            {
                soundAudio = audio;
                break;
            }
        }
        return soundAudio;
    }

}
