using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private void Awake()
    {
        postProcessIsOn = PlayerPrefs.GetInt("PostProcessing", 1) == 1;
        ppToggle.isOn = postProcessIsOn;
        OnClickQualityLevel(PlayerPrefs.GetInt("QualityLevel", 0));
    }
    //=======================================================================================================
    [SerializeField]
    GameObject[] qualityLevelMarkers = new GameObject[3];
    public void OnClickQualityLevel(int level)
    {
        if (level > 2 || level < 0) Debug.LogError("Quality settigs level out of range!");
        for (int i = 0; i < qualityLevelMarkers.Length; i++)
        {
            if (i == level)
            {
                qualityLevelMarkers[i].SetActive(true);
            }
            else
            {
                qualityLevelMarkers[i].SetActive(false);
            }
        }
        if (QualitySettings.GetQualityLevel() == level) return;
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("QualityLevel", level);
    }



    //===================================================================================================
    [SerializeField]
    Slider musicSlider, sfxSlider;
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
    public void OnChangedSFXSlider()
    {
        float volumeSetting = sfxSlider.value; // 0...1
        float vol = volumeSetting == 0 ? -80 : (volumeSetting * soundsVolumeMultiplier) - soundsVolumeMultiplier; // convert to DB
        musicMix.SetFloat("sfxVolume", vol);
    }
    //===================================================================================================
    public static bool postProcessIsOn = true;
    public static Action OnPostProcToggle;
    [SerializeField]
    Toggle ppToggle;
    public void OnTogglePP()
    {
        postProcessIsOn = !postProcessIsOn;
        if (OnPostProcToggle != null) OnPostProcToggle.Invoke();
        PlayerPrefs.SetInt("PostProcessing", postProcessIsOn ? 1 : 0);
    }
}
