using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
