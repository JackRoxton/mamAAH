using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster_script : MonoBehaviour
{
    [SerializeField] private Mum_script mum;
    [SerializeField] private GameObject underTheBed;
    [SerializeField] private GameObject nextToTheBed;
    [SerializeField] private GameObject OnTheBed;
    [SerializeField] private GameObject TV;
    [SerializeField] private AnimationCurve scaleCurve;

    [HideInInspector] public float advance = 0; // From 0 to 3
    private float advanceRate = .6f;
    [HideInInspector] public float advanceTarget = 0;

    public bool mumIsHere = false;

    private void Start()
    {
        UpdateLight(GameManager.Instance.GetLightState());
        //TV.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void Update()
    {
        advance = Mathf.Clamp(advanceTarget, advance - advanceRate * Time.deltaTime, advance + advanceRate * Time.deltaTime);
        if (advance < 1)
        {
            transform.position = Vector3.Lerp(underTheBed.transform.position, nextToTheBed.transform.position, advance);
            transform.localScale = Vector3.one;
        }
        else if (advance < 2)
        {
            transform.position = Vector3.Lerp(nextToTheBed.transform.position, OnTheBed.transform.position, advance - 1);
            transform.localScale = Vector3.one;
            //TV.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            //TV.GetComponent<SpriteRenderer>().color = Color.white;
            AudioManager.Instance.PlayScratching();
            transform.localScale = Vector3.one * scaleCurve.Evaluate(advance - 2);
            Vector3 minusZ = transform.position;
            minusZ.z = -.9f;
            transform.position = minusZ;
            if (advance >= 3) GameManager.Instance.GameOverMonster();
            PostProcessSript.Instance.vignetteValue = (advance - 2);
        }        
    }

    public void UpdateLight(bool val)
    {
        if (mumIsHere) return;
        advanceTarget = val ? 1 : 3;
        advanceRate = .3f;
    }

    public void MumIsComing(bool val)
    {
        mumIsHere = val;
        if (val)
        {
            advanceTarget = 0;
            advanceRate = 2;
        }
        else
        {
            advanceRate = .6f;
        }
    }
}
