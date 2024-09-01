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

    AudioManager instance;

    private void Start(){
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip){
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume, float pitch){
        SFXSource.clip = clip;
        SFXSource.pitch = pitch;
        SFXSource.volume = volume;
        SFXSource.Play();
    }
}
