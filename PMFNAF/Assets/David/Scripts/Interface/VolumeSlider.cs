using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] int _type = 0;
    [SerializeField] Slider _slider;
    private float _ogValue;
    public void ValueChanged(float volume)
    {
        AudioManager.Instance.SetVolumeOf(_type, volume);
    }
    private void Start()
    {
        switch (_type) {
            case 0:
                _ogValue = PlayerPrefs.GetFloat("MasterVolume");
                break;
            case 1:
                _ogValue = PlayerPrefs.GetFloat("MusicVolume");
                break;
            case 2:
                _ogValue = PlayerPrefs.GetFloat("SFXVolume");
                break;
        }
        _slider.value = _ogValue;
    }
}
