using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource introMusic, levelMusic, gameOverMusic, winMusic;
    [SerializeField] AudioSource[] sfx;


    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    void Awake()
    {
        instance = this;
    }



    private void LoadVolume() // Volume save in VolumeSetting.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1);

        mixer.SetFloat(VolumeSetting.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSetting.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }



    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }


    public void PlayLevelWin()
    {
        levelMusic.Stop();
        winMusic.Play();
    }


    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
