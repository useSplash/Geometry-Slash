using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start(){

        if(PlayerPrefs.HasKey("musicVolume")){
            LoadMusicVolume();
        }
        else{
            SetMusicVolume();
        }

        if(PlayerPrefs.HasKey("SFXVolume")){
            LoadSFXVolume();
        }
        else{
            SetSFXVolume();
        }
    }

    public void SetMusicVolume(){
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(){
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void LoadMusicVolume(){
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }

    public void LoadSFXVolume(){
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetSFXVolume();
    }

    public void SFXSliderSound(){
        audioManager.PlaySFX(audioManager.pixelBling, 1.0f, 1.0f);
    }
}
