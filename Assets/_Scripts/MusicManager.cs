using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for playing and tranisitoning music and modifying volume
/// </summary>
public class MusicManager : MonoBehaviour
{

    [SerializeField]
    AudioSource niceMusic;
    [SerializeField]
    AudioSource unhappyMusic;

    [SerializeField]
    AudioClip[] trackList;

    static bool spawned;

    public enum Track
    {
        Overworld,
        Battle
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (spawned)
        {
            Destroy(gameObject);
        }
        else
        {
            spawned = true;
        }
    }

    private void Start()
    {
        niceMusic.clip = trackList[0];
        unhappyMusic.clip = trackList[1];

    
        niceMusic.Play();
    }

    public void OnEncounterEnterHandler()
    {
        StartCoroutine(FadeOut(niceMusic, 3.0f));
        StartCoroutine(FadeIn(unhappyMusic, 3.0f));
    }

    public void OnEncounterExitHandler()
    {
        StartCoroutine(FadeOut(unhappyMusic, 0.5f));
        StartCoroutine(FadeIn(niceMusic, 3.0f));
    }


    // The following two functions are adapted from user chall3ng3r at https://forum.unity.com/threads/fade-out-audio-source.335031/
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
}
