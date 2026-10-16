using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioSource sfxSource;

    public AudioClip[] soundEffects;

    public void SetMusicVolume(float value)
    {
        mainMixer.SetFloat("MusicVolume", VolumeToDecibels(value));
    }

    public void SetSFXVolume(float value)
    {
        mainMixer.SetFloat("SFXVolume", VolumeToDecibels(value));
    }

    private float VolumeToDecibels(float value)
    {
        return value <= 0.0001f ? -80f : Mathf.Log10(value) * 20f;
    }

    public void PlayRandomSFX()
    {
        if (soundEffects.Length == 0) return;

        int index = Random.Range(0, soundEffects.Length);
        sfxSource.PlayOneShot(soundEffects[index]);
    }
}
