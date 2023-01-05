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
    public AnimationCurve curve;

    void Start()
    {
        Instance = this;

        // Create an instance of a vignette
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void Update()
    {
        // Change vignette intensity using a sinus curve
        m_Vignette.intensity.value = curve.Evaluate(vignetteValue);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
