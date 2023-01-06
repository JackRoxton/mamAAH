using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField]
    Light light = null;

    float lightIntensityVal;
    float baseIntensity;
    float blinkTimer = 0.2f;

    private void Start()
    {
        lightIntensityVal = light.intensity;
        baseIntensity = light.intensity;
    }

    void Update()
    {
        blinkTimer -= Time.deltaTime;
        if(blinkTimer <= 0)
        {
            lightIntensityVal += Random.Range(-0.1f, 0.1f);
            lightIntensityVal = Mathf.Clamp(lightIntensityVal, baseIntensity - 0.3f, baseIntensity + 0.3f);
            light.intensity = lightIntensityVal;
            blinkTimer = 0.2f + Random.Range(-0.1f, 0.1f);
        }
    }
}
