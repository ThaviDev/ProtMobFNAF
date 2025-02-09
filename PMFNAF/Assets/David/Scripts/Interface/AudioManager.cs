using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton para acceso global
    [SerializeField] AudioMixer _mixer;
    private const string _musicVolume = "MusicVolume";
    private const string _sFXVolume = "SFXVolume";
    private const string _masterVolume = "MasterVolume";
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);

        AudioManager.Instance.SetVolumeOf(1, musicVolume);
        AudioManager.Instance.SetVolumeOf(2, sfxVolume);
        AudioManager.Instance.SetVolumeOf(0, masterVolume);
    }
    public void SetVolumeOf(int type, float volume)
    {
        switch (type) {
            case 0:
                float volumeMaster = LinearToDecibel(volume);
                _mixer.SetFloat(_masterVolume, volumeMaster);
                PlayerPrefs.SetFloat("MasterVolume", volume);
                break;
            case 1:
                float volumeMusic = LinearToDecibel(volume);
                _mixer.SetFloat(_musicVolume, volumeMusic);
                PlayerPrefs.SetFloat("MusicVolume", volume);
                break;
            case 2:
                float volumeSFX = LinearToDecibel(volume);
                _mixer.SetFloat(_sFXVolume, volumeSFX);
                PlayerPrefs.SetFloat("SFXVolume", volume);
                break;
        }
        PlayerPrefs.Save();
    }
    private float LinearToDecibel(float linear)
    {
        if (linear <= 0) return -80f; // Mute si el volumen es 0
        return Mathf.Log10(linear) * 20f;
    }
}