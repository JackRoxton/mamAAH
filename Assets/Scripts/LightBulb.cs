using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField]
    Light RoomLight = null;

    //état allumé éteint
    public bool lightState = true;

    Animator animator = null;

    float blinkTimer = 8;

    void Start()
    {
        GameManager.Instance.Light = this;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (lightState == false)
            return;

        blinkTimer -= Time.deltaTime;
        animator.SetFloat("blinkingTimer",blinkTimer);
        if(blinkTimer <= 0)
        {
            blinkTimer = 8 + Random.Range(-2,3);
        }
    }

    public void animSetLightIntensity(float intensity)
    {
        RoomLight.intensity = intensity;
    }

    //allumer et éteindre la lumière
    public void SwitchLight()
    {
        if (lightState)
        {
            RoomLight.intensity = 0;
            lightState = false;
            //this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            RoomLight.intensity = 8;
            lightState = true;
            //this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
