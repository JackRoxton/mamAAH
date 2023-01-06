using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessSript : MonoBehaviour
{
    public float vignetteValue;
    public static PostProcessSript Instance;

    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    Grain grain;
    public AnimationCurve curve;

    void Start()
    {
        Instance = this;

        // Create an instance of a vignette
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        grain = ScriptableObject.CreateInstance<Grain>();
        grain.enabled.Override(true);
        grain.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, grain);
    }

    void Update()
    {
        // Change vignette intensity using a sinus curve
        m_Vignette.intensity.value = curve.Evaluate(vignetteValue);
        grain.intensity.value = .8f + Mathf.Sin(Time.timeSinceLevelLoad * vignetteValue) * 2;
        grain.size.value = Mathf.Sin(Time.timeSinceLevelLoad * 4);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
