using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;

    public AudioManager audioManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadValues();

        audioManager.SetMusicVolume(musicSlider.value);
        audioManager.SetSFXVolume(sfxSlider.value);

        ChangeValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValue()
    {
        musicText.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        sfxText.text = Mathf.RoundToInt(sfxSlider.value * 100) + "%";
    }

    public void LoadValues()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicValue", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    public void SaveMusicValues()
    {
        PlayerPrefs.SetFloat("MusicValue", musicSlider.value);
        PlayerPrefs.Save();
    }

    public void SaveSFXValue()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }


}
