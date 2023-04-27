using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("SoundFX")]
    public AudioClip[] soundsFX; // khởi tạo 1 mảng audio clip (sfx)
    [Header("Music")]
    public AudioClip[] soundsMusic; // khởi tạo 1 mảng audio clip (music)

    [Space]
    public AudioSource soundSource;// nguồn để phát âm thanh sfx
    public AudioSource musicSource;// nguồn để phát âm thanh music

    [Header("Music")]
    public bool TurnOnAudio = true;
    string lastBG;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length <= 1)
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayOneShot(string name, float volume = 1)
    {
        if (!TurnOnAudio) return;
        AudioClip s = Array.Find(soundsFX, sound => sound.name == name);// tìm kiếm âm thanh trong mảng audio sfx
        if (s != null) // nếu audio có (!= null)
        {
            soundSource.clip = s; // gán âm thanh chạy là âm thanh đó
            soundSource.PlayOneShot(s, volume); // play âm thanh đó lên
        }
    }

    public void PlayMusic(string name, float volume = 1)
    {
        if (!TurnOnAudio) return;
        var audioClip = Array.Find(soundsMusic, sound => sound.name == name);
        if (audioClip != null)
        {
            lastBG = name;
            musicSource.clip = audioClip;
            musicSource.volume = volume;
            musicSource.Play();
        }
    }
}