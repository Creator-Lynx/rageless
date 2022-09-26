using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public void OnClickLow()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void OnClickMid()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void OnClickHigh()
    {
        QualitySettings.SetQualityLevel(5);
    }

    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    AudioMixer musicMix;
    [SerializeField]
    float soundsVolumeMultiplier = 80;
    public void OnChangedMusicSlider()
    {
        float volumeSetting = musicSlider.value; // 0...1
        float vol = volumeSetting == 0 ? -80 : (volumeSetting * soundsVolumeMultiplier) - soundsVolumeMultiplier; // convert to DB
        musicMix.SetFloat("musicVolume", vol);
    }
}
