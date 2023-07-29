using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour 
{
    [Header("Music and Sound")]
    public AudioSource musicAudioSources;
    public AudioSource soundAudioSources;
    private int IntMusic;

    [Header("Music Panel")]
    public Animation MusicAnimation;
    public Button MusicButton;

    public void MusicSystem()
    {
        IntMusic += 1;

        // Off Music
        if (IntMusic == 1)
        {
            musicAudioSources.Stop();
            MusicAnimation.Play("MusicOff");
            MusicButton.interactable = false;
            StartCoroutine (WaitSystem());
        }

        // On Music
        if (IntMusic == 2)
        {
            musicAudioSources.Play();
            MusicAnimation.Play("MusicOn");
            MusicButton.interactable = false;
            StartCoroutine (WaitSystem());

            IntMusic = 0;
        }
    }

    IEnumerator WaitSystem () 
    {
        yield return new WaitForSeconds (0.5f);
        MusicButton.interactable = true;
    }

    public void SoundSystem()
    {
        soundAudioSources.Play();
    }
}