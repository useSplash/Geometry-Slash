using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header(" ----------------- Audio Source ----------------- ")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header(" ----------------- Audio Clip ----------------- ")]

    [Header("Music")]
    public AudioClip mainTitleBGM;

    [Header("SFX")]
    public AudioClip lightHit1SFX;
    public AudioClip lightHit2SFX;
    public AudioClip heavyHit1SFX;
    public AudioClip heavyHit2SFX;
    public AudioClip gameboyPluck;
    public AudioClip pixelPew;
    public AudioClip pixelBling;

    private void Start(){
        PlayMusic(mainTitleBGM);
    }

    public void PlayMusic(AudioClip clip){
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.clip = clip;
        SFXSource.Play();
    }
}
